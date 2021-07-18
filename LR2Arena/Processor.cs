using System;
using System.Collections.Concurrent;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LR2Arena
{
    class Processor
    {
        private BlockingCollection<byte[]> queue;
        private Form1 form;
        private String bmsMd5;
        private uint p1exScore;
        private uint p2exScore;

        public Processor(BlockingCollection<byte[]> queue, Form1 form)
        {
            this.queue = queue;
            this.form = form;
            this.p1exScore = 0;
            this.p2exScore = 0;
        }

        public void Process()
        {
            byte[] recvBuffer = queue.Take();
            int id = recvBuffer[0];
            switch (id) {
                case 1: // BMS path
                    string bmsPath = Encoding.GetEncoding(932).GetString(recvBuffer).Substring(1);
                    form.SetBmsPathTextBox(bmsPath);
                    using (MD5 md5 = MD5.Create())
                    {
                        using (FileStream stream = File.OpenRead(bmsPath))
                        {
                            byte[] hash = md5.ComputeHash(stream);
                            bmsMd5 = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                        }
                    }
                    form.SetBmsMd5TextBox(bmsMd5);
                    break;
                case 2: // Score
                    uint poor = BitConverter.ToUInt32(recvBuffer, 1);
                    uint bad = BitConverter.ToUInt32(recvBuffer, 5);
                    uint good = BitConverter.ToUInt32(recvBuffer, 9);
                    uint great = BitConverter.ToUInt32(recvBuffer, 13);
                    uint pGreat = BitConverter.ToUInt32(recvBuffer, 17);
                    uint maxCombo = BitConverter.ToUInt32(recvBuffer, 21);
                    uint score = BitConverter.ToUInt32(recvBuffer, 25);
                    uint exScore = great + 2 * pGreat;
                    //form.AddLogTextBoxLine($"PGreat: {pGreat}, Great: {great}, Good: {good}, Bad: {bad}, Poor: {poor}, Max combo: {maxCombo}, Score: {score}, ExScore: {exScore}");
                    if (exScore > p1exScore)
                    {
                        p1exScore = exScore;
                        UdpManager.RemoteSendExScore(p1exScore);
                        form.UpdateGraph(p1exScore, 0);
                    }
                    break;
                default:
                    Console.Error.WriteLine("Invalid operation");
                    break;
            }
        }

        public void ProcessRemote()
        {
            byte[] recvBuffer = queue.Take();
            uint exScore = BitConverter.ToUInt32(recvBuffer, 0);
            form.AddLogTextBoxLine($"+++ P2 ExScore: {exScore}");
            if (exScore > p2exScore)
            {
                p2exScore = exScore;
                UdpManager.UpdatePacemaker(p2exScore);
                form.UpdateGraph(p2exScore, 1);
            }
        }
    }
}
