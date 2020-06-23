using System;
using System.Collections.Generic;

namespace Csharp_generic
{
    class ArrayClass<T>
    {
        T[] arr = new T[5];

        public T this[int index]
        {
            get
            { 
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }

        public int Lenth
        {
            get
            {
                return arr.Length;
            }
        }
    }

    interface IPrint
    {
        void Print();
    }

    class ColorPrinter : IPrint
    {
        public void Print()
        {
            Console.WriteLine("ColorPrinter!!");
        }
    }

    class BarcodePrinter : IPrint
    {
        public void Print()
        {
            Console.WriteLine("BarcodePrinter!!");
        }
    }

    class Office
    {
        public static void Print<T>(T printer) where T : IPrint
        {
            printer.Print();
        }
    }

    class MainClass
    {
        public static void ArrayPrint<T>(T[] arr)
        {
            Console.Write($"{arr.GetType()} : ");
            foreach (var e in arr)
                Console.Write($"{e} ");
            Console.WriteLine("");
        }

        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        public static void Main(string[] args)
        {
            ArrayPrint<int>(new[] { 1, 2, 3, 4, 5 });
            ArrayPrint<string>(new[] { "One", "Two", "Three", "Four", "Five" });
            ArrayPrint<double>(new[] { 1.1, 2.2, 3.3, 4.4, 5.5 });

            ArrayClass<int> intArr = new ArrayClass<int>();
            ArrayClass<double> doubleArr = new ArrayClass<double>();

            for (int i = 0; i < intArr.Lenth; i++)
                intArr[i] = i+1;

            for (int i = 0; i < intArr.Lenth; i++)
                Console.Write($"{intArr[i]} ");
            Console.WriteLine("");

            for (int i = 0; i < doubleArr.Lenth; i++)
                doubleArr[i] = i + 1.1;

            for (int i = 0; i < doubleArr.Lenth; i++)
                Console.Write($"{doubleArr[i]} ");
            Console.WriteLine("");

            Office.Print<IPrint>(CreateInstance<ColorPrinter>());
            Office.Print<IPrint>(CreateInstance<BarcodePrinter>());

            Dictionary<string, IPrint> dict = new Dictionary<string, IPrint>();
            dict.Add("Canon", CreateInstance<ColorPrinter>());
            dict.Add("Xerox", CreateInstance<BarcodePrinter>());
            dict["Canon"].Print();
            dict["Xerox"].Print();
        }
    }
}
