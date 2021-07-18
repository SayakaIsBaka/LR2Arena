using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR2Arena
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();

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
                Console.Error.WriteLine("Could not inject the dll to LR2, exiting...");
                Environment.Exit(ret);
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

            Application.Run(form);
        }

        static void StartUdpReceiver(int port, BlockingCollection<byte[]> queue)
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
