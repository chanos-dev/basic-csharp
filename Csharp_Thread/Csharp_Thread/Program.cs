using System;
using System.ComponentModel;
using System.Threading;

namespace Csharp_Thread
{
    class MainClass
    {  
        public static void Main(string[] args)
        {
            Console.WriteLine("Start!!");

            Thread t1 = new Thread(new ThreadStart(Print));
            t1.Start();

            Thread t2 = new Thread(Print);
            t2.Start();

            Thread t3 = new Thread(delegate ()
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : Print()");
            });
            t3.Start();

            Thread t4 = new Thread(() => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : Print()"));
            t4.Start();

            new Thread(Print).Start();

            Thread t5 = new Thread(new ParameterizedThreadStart(square));
            t5.Start(5);

            Thread t6 = new Thread(() => Sum(new int[] { 10, 20, 30, 40, 50 }));
            t6.Start();

            ThreadPool.QueueUserWorkItem(square, 6);
            ThreadPool.QueueUserWorkItem(new WaitCallback(square), 7);
            ThreadPool.QueueUserWorkItem(square, 8);

            Console.WriteLine("End");

            Func<int, int, int> work = GetAdd;
            Func<int, int> work2 = (n) => n * n;

            IAsyncResult asyncAdd = work.BeginInvoke(20, 30, null, null);
            IAsyncResult asyncMinus = work2.BeginInvoke(20, null, null);
            
            Console.WriteLine("Add 20, 30");
            Console.WriteLine("Minus 30, 10");

            int result = work.EndInvoke(asyncAdd);
            int result2 = work2.EndInvoke(asyncMinus);

            Console.WriteLine($"Add : {result}, Minus : {result2}");

        }

        private static void Print()
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : Print()");
        }

        private static void square(object p)
        {
            int result = (int)p;
            Console.WriteLine($"{result * result}");
        }

        private static void Sum(int[] param)
        {
            int result = 0;
            for (int i = 0; i < param.Length; i++)
                result += param[i];

            Console.WriteLine($"sum : {result}");
        }

        private static int GetAdd(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
