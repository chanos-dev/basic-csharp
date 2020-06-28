using System;

namespace Csharp_delegateAndevent
{
    class MainClass
    {
        private delegate void MyDelegate();

        private static void Print()
        {
            Console.WriteLine("Delegate!!");
        }

        private static void Print_two()
        {
            Console.WriteLine("Delegate_two!!");
        }

        private delegate int Compare(int a, int b);

        private static int compare(int a, int b)
        {
            if (a >= b)
                return 1;
            else
                return 0;
        }

        private static void BubbleSort(int[] arr, Compare compare)
        {
            int temp; int length = arr.Length - 1;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length - i; j++)
                {
                    if (compare(arr[j], arr[j + 1]) > 0)
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        private delegate bool DelgenericSwap<T>(ref T t1, ref T t2);

        private static bool genericSwap<T>(ref T t1, ref T t2)
        {
            try
            {
                T temp;
                temp = t1;
                t1 = t2;
                t2 = temp;
            }
            catch
            {
                return false;
            }
            return true;
        }

        private delegate int DelgenericCompare<T>(T t1, T t2);

        private static int genericCompare<T>(T t1, T t2) where T : IComparable<T>
        {
            return t1.CompareTo(t2);
        }  

        private static void genericBubbleSort<T>(T[] arr, DelgenericCompare<T> compare, DelgenericSwap<T> swap)
        {
            int length = arr.Length - 1;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length - i; j++)
                {
                    if (compare(arr[j], arr[j + 1]) > 0)
                    {
                        swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }

        private delegate int Calculate(int a, int b);

        private static int Add(int a, int b, Calculate calculate)
        {
            return calculate(a, b);
        }

        private static void call(string msg)
        {
            Console.WriteLine($"{msg}, call event!!");
        }

        public static void Main(string[] args)
        {
            MyDelegate myDelegate = new MyDelegate(Print);
            myDelegate();

            myDelegate = new MyDelegate(Print_two);
            myDelegate();

            int[] arr = { 5, 4, 3, 2, 1, 6 };
            foreach (int e in arr)
                Console.Write($"{e} ");
            Console.WriteLine("");

            BubbleSort(arr, compare); 
            foreach (int e in arr)
                Console.Write($"{e} ");
            Console.WriteLine("");

            double[] doubleArr = { 5.5, 4.4, 3.3, 2.2, 1.1, 6.6 };

            foreach (double e in doubleArr)
                Console.Write($"{e} ");
            Console.WriteLine("");

            genericBubbleSort<double>(doubleArr,
                                      new DelgenericCompare<double>(genericCompare),
                                      new DelgenericSwap<double>(genericSwap));
            foreach (double e in doubleArr)
                Console.Write($"{e} ");
            Console.WriteLine("");

            MyDelegate myDelegate1 = new MyDelegate(Print);
            myDelegate1 += new MyDelegate(Print_two);

            myDelegate1();

            myDelegate1 = null;

            myDelegate1 = (MyDelegate)Delegate.Combine(new MyDelegate(Print),
                                                       new MyDelegate(Print_two));
            myDelegate1();

            myDelegate1 = null;

            myDelegate1 = new MyDelegate(Print)
                        + new MyDelegate(Print_two);

            myDelegate1();

            Calculate Calc;
            Calc = delegate (int a, int b)
            {
                return a + b;
            };

            Console.WriteLine($"{Calc(5, 10)}");

            int addNum = Add(10, 50, delegate (int a, int b)
            {
                return a + b;
            });

            Console.WriteLine($"{addNum}");

            EventHandler.CallEvent += call;
            
            EventHandler.printEvent("Mike");
        }
    } 

    class EventHandler
    {
        public delegate void eventMessage(string msg);
        public static event eventMessage CallEvent;

        public static void printEvent(string msg)
        {
            CallEvent(msg);
        } 
    }
}