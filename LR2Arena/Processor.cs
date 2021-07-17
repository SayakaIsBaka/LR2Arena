using System;
using System.Collections.Concurrent;
using System.Text;

namespace LR2Arena
{
    class Processor
    {
        private BlockingCollection<byte[]> queue;

        public Processor(BlockingCollection<byte[]> queue)
        {
            this.queue = queue;
        }

        public void Process()
        {
            byte[] recvBuffer = queue.Take();
            int id = recvBuffer[0];
            Console.WriteLine("Operation: " + id);
            switch (id) {
                case 1: // BMS path
                    string bmsPath = Encoding.GetEncoding(932).GetString(recvBuffer).Substring(1);
                    Console.WriteLine(bmsPath);
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
                    Console.WriteLine($"PGreat: {pGreat}, Great: {great}, Good: {good}, Bad: {bad}, Poor: {poor}, Max combo: {maxCombo}, Score: {score}, ExScore: {exScore}");
                    break;
                default:
                    Console.Error.WriteLine("Invalid operation");
                    break;
            }
        }
    }
}
