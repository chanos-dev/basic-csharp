using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_asyncAndawait
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DoWork();

            for(int i=0; i<10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Hello World! : {i+1}");
            }            
        }

        private async static void DoWork()
        {
            Task<int> task = Task<int>.Factory.StartNew(() => square(5));

            Console.WriteLine("Before Dowork");

            await task;

            Console.WriteLine($"Dowork : {task.Result}");
        }

        private static int square(int num)
        {
            Thread.Sleep(5000);

            return num * num;
        }
    }
}
