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
        private static String bmsMd5 = "";
        private static String p2Md5 = "";
        private static bool sentHash = false;
        private static bool receivedHash = false;
        private static uint p1exScore = 0;
        private static uint p2exScore = 0;

        public Processor(BlockingCollection<byte[]> queue, Form1 form)
        {
            this.queue = queue;
            this.form = form;
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
                    UdpManager.RemoteSendWithId(2, Encoding.ASCII.GetBytes(bmsMd5));
                    sentHash = true;
                    form.AddLogTextBoxLine("Waiting for P2 to be ready...");
                    p1exScore = 0;
                    p2exScore = 0;
                    form.UpdateGraph(0, 0);
                    form.UpdateGraph(0, 1);
                    form.SetBmsMd5TextBox(bmsMd5);
                    if (receivedHash) // Might be ready here if not host
                    {
                        CheckHashAndSendP2Ready();
                    }
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
            int id = recvBuffer[0];
            switch (id)
            {
                case 1: // P2 exscore
                    uint exScore = BitConverter.ToUInt32(recvBuffer, 1);
                    form.AddLogTextBoxLine($"+++ P2 ExScore: {exScore}");
                    if (exScore > p2exScore)
                    {
                        p2exScore = exScore;
                        UdpManager.UpdatePacemaker(p2exScore);
                        form.UpdateGraph(p2exScore, 1);
                    }
                    break;
                case 2: // P2 hash (is ready)
                    p2Md5 = Encoding.ASCII.GetString(recvBuffer).Substring(1);
                    receivedHash = true;
                    form.AddLogTextBoxLine("Remote MD5: " + p2Md5);
                    if (sentHash) // Might be ready here if host
                    {
                        CheckHashAndSendP2Ready();
                    }
                    break;
            }
        }

        private void CheckHashAndSendP2Ready()
        {
            Console.WriteLine("-----");
            Console.WriteLine("p2md5: " + p2Md5);
            Console.WriteLine("bmsMd5: " + bmsMd5);

            if (p2Md5.Equals(bmsMd5))
            {
                SendP2ReadyToLR2();
                form.AddLogTextBoxLine("P2 ready!");
            }
            else
            {
                form.AddLogTextBoxLine($"Mismatching MD5: {bmsMd5} (local) vs {p2Md5} (remote)");
            }
        }

        private void SendP2ReadyToLR2()
        {
            sentHash = false;
            receivedHash = false;
            UdpManager.SendP2ReadyToLR2();
        }
    }
}
