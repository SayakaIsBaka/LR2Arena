using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace LR2Arena
{
    static class Init
    {
        public static bool Initialize(Form1 form)
        {
            string dllPath = AppDomain.CurrentDomain.BaseDirectory + "/LR2mind.dll";
            string[] processNames = { "LRHbody", "LR2body" };
            int ret = 0;

            foreach (string processName in processNames)
            {
                Injector injector = new Injector(processName);
                ret = injector.Inject(dllPath);
                if (ret == 0) break;
            }

            if (ret != 0)
            {
                Console.Error.WriteLine("Could not inject the dll to LR2");
                return false;
            }

            BlockingCollection<byte[]> queue = new BlockingCollection<byte[]>();
            StartUdpReceiver(2222, queue); // LR2Arena <-> LR2Mind

            BlockingCollection<byte[]> remoteQueue = new BlockingCollection<byte[]>();
            StartUdpReceiver(2224, remoteQueue); // LR2Arena <-> LR2Arena (remote)

            Task.Run(() =>
            {
                Processor processor = new Processor(queue, form);
                while (true)
                {
                    processor.Process();
                }
            });

            Task.Run(() =>
            {
                Processor processor = new Processor(remoteQueue, form);
                while (true)
                {
                    processor.ProcessRemote();
                }
            });

            UdpManager.SendRandomFlipToLR2(form.IsRandomFlipEnabled());
            return true;
        }

        private static void StartUdpReceiver(int port, BlockingCollection<byte[]> queue)
        {
            Thread receiverThread = new Thread(
                delegate ()
                {
                    UdpManager receiver = new UdpManager(port, queue);
                    receiver.Listen();
                });
            receiverThread.Start();
        }
    }
}
