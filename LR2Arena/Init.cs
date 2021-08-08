using System;
using System.Collections.Concurrent;
using System.Diagnostics;
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
            int ret = 1;

            foreach (string processName in processNames)
            {
                Process lr2Process = GetLr2Process(processName);
                if (lr2Process != null) {
                    Injector injector = new Injector(lr2Process, processName);
                    ret = injector.Inject(dllPath);
                    Database.SetDbPathFromLr2Executable(lr2Process.MainModule.FileName);
                    break;
                }
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

            return true;
        }

        private static Process GetLr2Process(string processName)
        {
            Process[] lr2Processes = Process.GetProcessesByName(processName);
            if (lr2Processes.Length == 0)
            {
                Console.Error.WriteLine(processName + " process not found");
                return null;
            }
            Console.WriteLine(processName + " process found");

            return lr2Processes[0];
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
