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
                    byte[] generatedRandom = ParseRandom(recvBuffer);
                    LogRandom(generatedRandom, false);
                    string bmsPath = Encoding.GetEncoding(932).GetString(recvBuffer, 1 + 7 * sizeof(uint), recvBuffer.Length - 1 - 7 * sizeof(uint));
                    form.SetBmsPathTextBox(bmsPath);
                    using (MD5 md5 = MD5.Create())
                    {
                        using (FileStream stream = File.OpenRead(bmsPath))
                        {
                            byte[] hash = md5.ComputeHash(stream);
                            bmsMd5 = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                        }
                    }
                    string bmsInfo = BuildBmsInfoString(bmsPath);
                    form.SetBmsInfoLocalTextBox(bmsInfo);
                    byte[] byteBmsInfo = Encoding.GetEncoding(932).GetBytes(bmsMd5 + bmsInfo);
                    byte[] dataToSend = new byte[generatedRandom.Length + byteBmsInfo.Length];
                    Buffer.BlockCopy(generatedRandom, 0, dataToSend, 0, generatedRandom.Length);
                    Buffer.BlockCopy(byteBmsInfo, 0, dataToSend, generatedRandom.Length, byteBmsInfo.Length);
                    UdpManager.RemoteSendWithId(2, dataToSend);
                    sentHash = true;
                    form.AddLogTextBoxLine("Waiting for P2 to be ready...");
                    ResetGraph();
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
                case 3: // Escaped
                    form.AddLogTextBoxLine("Cancelled loading...");
                    form.SetBmsInfoLocalTextBox("");
                    CancelReady();
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
                    byte[] receivedRandom = ParseRandom(recvBuffer);
                    string bmsInfo = Encoding.GetEncoding(932).GetString(recvBuffer, 1 + 7 * sizeof(uint), recvBuffer.Length - 1 - 7 * sizeof(uint));
                    p2Md5 = bmsInfo.Substring(0, 32);
                    string p2Bms = bmsInfo.Substring(32);
                    if (!Database.IsBmsPresentInDb(p2Md5))
                    {
                        form.AddLogTextBoxLine("You do not have the chart selected by P2...");
                        // insert notification to remote here
                        break;
                    }
                    form.SetBmsInfoRemoteTextBox(p2Bms);
                    receivedHash = true;
                    form.AddLogTextBoxLine("Remote MD5: " + p2Md5);
                    if (sentHash) // Might be ready here if host
                    {
                        CheckHashAndSendP2Ready();
                    }
                    else
                    {
                        UdpManager.SendRandomToLR2(receivedRandom);
                        LogRandom(receivedRandom, true);
                    }
                    break;
                case 3: // Escaped
                    receivedHash = false;
                    form.AddLogTextBoxLine("P2 went back to the menu...");
                    form.SetBmsInfoRemoteTextBox("");
                    break;
                case 98: // Connectivity check (request)
                    UdpManager.SendConnectivityRequestAnswer();
                    break;
                case 99: // Connectivity check (answer)
                    form.EnableConnectivityCheckButton();
                    break;
                default:
                    Console.Error.WriteLine("Invalid operation");
                    break;

            }
        }

        private byte[] ParseRandom(byte[] buffer)
        {
            byte[] currentRandom = new byte[7 * sizeof(uint)];
            Buffer.BlockCopy(buffer, 1, currentRandom, 0, 7 * sizeof(uint));
            return currentRandom;
        }

        private void LogRandom(byte[] random, bool remote)
        {
            uint[] randomUint = new uint[7];
            Buffer.BlockCopy(random, 0, randomUint, 0, 7 * sizeof(uint));
            string textRandom = "Generated random:";
            if (remote)
                textRandom = "Received random to apply: ";
            for (int i = 0; i < randomUint.Length; i++)
            {
                textRandom += $" {randomUint[i]}";
            }
            form.AddLogTextBoxLine(textRandom);
        }

        private void ResetGraph()
        {
            p1exScore = 0;
            p2exScore = 0;
            form.UpdateGraph(0, 0);
            form.UpdateGraph(0, 1);
        }

        private string BuildBmsInfoString(string bmsPath)
        {
            BmsHeader bms = GetInfoFromBMS(bmsPath);
            if (bms == null)
                return "";
            return $"{bms.Title} {bms.SubTitle} / {bms.Artist} {bms.SubArtist}";
        }

        private BmsHeader GetInfoFromBMS(string bmsPath)
        {
            try
            {
                using (FileStream stream = File.OpenRead(bmsPath))
                {
                    BmsParser parser = new BmsParser();
                    BmsHeader bms = parser.Parse(stream);
                    return bms;
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return null;
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

        private void CancelReady()
        {
            sentHash = false;
            UdpManager.RemoteSend(new byte[] { 3 });
        }

        private void SendP2ReadyToLR2()
        {
            sentHash = false;
            receivedHash = false;
            UdpManager.SendP2ReadyToLR2();
        }
    }
}
