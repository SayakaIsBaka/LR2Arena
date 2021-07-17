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

            Thread receiverThread = new Thread(
                delegate ()
                {
                    UdpManager receiver = new UdpManager(2222, queue);
                    receiver.Listen();
                });
            receiverThread.Start();

            Task.Run(() =>
            {
                Processor processor = new Processor(queue);
                while (true)
                {
                    processor.Process();
                }
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
