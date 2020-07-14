using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_Task
{
    class MainClass
    {
        private static CancellationTokenSource cancelTokenSource;

        public static void Main(string[] args)
        {
            Task.Factory.StartNew(new Action<object>(Run), null);
            Task.Factory.StartNew(new Action<object>(Run), "One");
            Task.Factory.StartNew(Run, "Two");


            Task task1 = new Task(new Action(Print));

            Task task2 = new Task(() => Console.WriteLine("Print task lambda"));

            task1.Start();

            task2.Start();

            task1.Wait();
            task2.Wait();


            Task<int> task3 = Task.Factory.StartNew<int>(() => GetStringLength("Hello"));

            int LenString = task3.Result;

            Console.WriteLine($"Len : {LenString}");

            Do_Work();

            Thread.Sleep(3000);

            //cancelTokenSource.Cancel(); 

            Console.ReadLine();
        }

        private static async void Do_Work()
        {
            cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            var task4 = Task.Factory.StartNew<object>(GetNumberSum, token);

            var res = await task4;

            if(res != null)
            {
                Console.WriteLine($"{res}");
            }
            else
            {
                Console.WriteLine("Cancelled");
            }
        }

        private static void Run(object data)
        {
            Console.WriteLine(data is null ? "Null" : data);
        }

        private static void Print()
        {
            Console.WriteLine("Print task");
        }

        private static int GetStringLength(string msg)
        {
            return msg is null ? -1 : msg.Length;
        }

        private static object GetNumberSum()
        {
            int sum = 0;

            for(int i=0; i<30; i++)
            {
                if(cancelTokenSource.Token.IsCancellationRequested)
                {
                    return null;
                }

                sum += i + 1;
                Thread.Sleep(100);
            }

            return sum;
        }
    }
}
