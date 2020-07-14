using System;
using System.ComponentModel;
using System.Threading;

namespace Csharp_BackgroundWorker
{
    class MainClass
    {
        private static BackgroundWorker worker;

        private static void initialize()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += new DoWorkEventHandler(worker_Dowork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        public static void Main(string[] args)
        {
            initialize();
            Console.WriteLine("Start");
            worker.RunWorkerAsync();
            Console.WriteLine("End");

            Thread.Sleep(1000);
            worker.CancelAsync();

            Console.ReadLine();
        }

        private static void worker_Dowork(object sender, DoWorkEventArgs e)
        {
            int add = 0;

            for (int i = 1; i <= 100; i++)
            {
                if(worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                add += i;
                worker.ReportProgress(i, "for");
                Thread.Sleep(100);
            }

            e.Result = add;
        }

        private static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine($"{e.UserState} Progress : {e.ProgressPercentage}");
        }

        private static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Console.WriteLine("worker cancled!!");
            }
            else
            {
                Console.WriteLine($"RunWorkerCompleted : {e.Result}");
            }
        }
    }
}
