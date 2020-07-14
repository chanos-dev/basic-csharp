using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_Parallel
{
    class MainClass
    {
        const int MAX = 10000000;
        const int SHIFT = 3;

        public static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : {i + 1}");


            Parallel.For(0, 100, (i) =>
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : {i + 1}");
            });

            Parallel.Invoke(
                () => Run1(),
                () => Run2(),
                () => Run3(),
                () => Run4());

            int[] intArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };

            Parallel.ForEach<int>(intArr, n =>
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : {square(n)}");
            });

            Console.ReadLine();
        }

        private static void Run1()
        {
            Console.WriteLine("Run1");
        }

        private static void Run2()
        {
            Console.WriteLine("Run2");
        }

        private static void Run3()
        {
            Console.WriteLine("Run3");
        }

        private static void Run4()
        {
            Console.WriteLine("Run4");
        }

        private static int square(int num)
        {
            return num * num;
        }
    }
}
