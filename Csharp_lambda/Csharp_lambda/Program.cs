using System;
using System.Collections.Generic;

namespace Csharp_lambda
{

    class LambdaClass
    {
        private List<int> list = new List<int>();

        public void Add(int num) => list.Add(num);
        public void Remove(int num) => list.Remove(num);

        //public int this[int index] => list[index];
        public int this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }

        public int GetLength => list.Count; 

        private string Info;

        public LambdaClass(string info) => this.Info = info;

        public void PrintInfo()
        {
            Console.WriteLine($"{Info}");
        }

        public void LambdaPrint(string msg) => Console.WriteLine($"{msg}, Print Lambda method!!");
    }

    class MainClass
    {
        delegate int Calculate(int a, int b);

        delegate void Print();

        delegate string stringCombine(string[] Stringarr);

        public static void Main(string[] args)
        {
            Calculate calc = (a, b) => a + b;

            Console.WriteLine($"{calc(5, 10)}");

            Print print = () =>
            {
                Console.WriteLine("One");
                Console.WriteLine("Two");
                Console.WriteLine("Three");
            };

            print();


            stringCombine stringCombine = (sarr) =>
            {
                string str = string.Empty;
                foreach (string e in sarr)
                    str += e + @"\";

                return str;
            };

            string path = stringCombine(new string[] { "C:", "drive", "csharp" });
            Console.WriteLine($"{path}");

            Func<int> func = () =>
            {
                Console.WriteLine("Func!!");
                return -1;
            };

            if (func() < 0)
                Console.WriteLine(" < 0 ");

            Func<int, string> func2 = (x) =>
            {
                Console.WriteLine("int to string!!");
                return x.ToString() + " string!!";
            };

            string intStr = func2(10);
            Console.WriteLine($"{intStr}");

            Func<double, double, double> func3 = (x, y) => x / y;
            Console.WriteLine($"{func3(10, 3)}");

            Action action = () => Console.WriteLine("print action");

            action();

            Action<string> action2 = (msg) => Console.WriteLine($"{msg}");

            action2("print action2!!");

            int result = 0;

            Action<int, int> action3 = (a, b) => result = a + b;
            action3(10, 20);

            Console.WriteLine($"{result}");

            LambdaClass lambdaClass = new LambdaClass("This is LambdaClass!!");
            lambdaClass.PrintInfo();
            lambdaClass.LambdaPrint("Piter");

            for (int i = 0; i < 5; i++)
                lambdaClass.Add(i + 1);


            for (int i = 0; i < lambdaClass.GetLength; i++)
                Console.Write($"{lambdaClass[i]} ");
            Console.WriteLine("");

            for (int i = 0; i < lambdaClass.GetLength; i++)
            {
                lambdaClass[i]++;
                Console.Write($"{lambdaClass[i]} ");
            }
            Console.WriteLine("");

            for (int i = 0; i < lambdaClass.GetLength; i++)
                if ((lambdaClass[i] % 2) == 1)
                    lambdaClass.Remove(lambdaClass[i]);

            for (int i = 0; i < lambdaClass.GetLength; i++)
                Console.Write($"{lambdaClass[i]} ");
            Console.WriteLine("");

        }
    } 
}
