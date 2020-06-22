using System;
using System.Collections;


namespace Csharp_collectionAndindexer
{
    class MainClass
    {

        private static void Print(int Value)
        {
            if (Value >= 20)
                Console.Write($"{Value} ");
        }

        private static bool passNumber(int Value)
        {
            if (Value >= 10)
                return true;
            else
                return false;

        }

        public static void Main(string[] args)
        {
            //Array Method//
            int[] arr = new int[3] { 30, 40, 50 };
            int[] arr2 = new int[] { 60, 70, 80 };
            int[] arr3 = { 90, 100, 110 };

            foreach (int e in arr)
                Console.Write($"{e} ");
            Console.WriteLine("");

            foreach (int e in arr2)
                Console.Write($"{e} ");
            Console.WriteLine("");

            foreach (int e in arr3)
                Console.Write($"{e} ");
            Console.WriteLine("");

            int[] arrMethod = { 10, 50, 30, 40, 20 };
            foreach (int e in arrMethod)
                Console.Write($"{e} ");
            Console.WriteLine("");

            Array.Sort(arrMethod);
            Array.ForEach<int>(arrMethod, new Action<int>(Print));
            Console.WriteLine("");

            Console.WriteLine($"Array : {arrMethod.Rank}");

            int[,] tarr = { { 0, 0, 0}, { 1, 1, 1} };
            Console.WriteLine($"Array : {tarr.Rank}");

            Console.WriteLine($"Length : {arrMethod.Length}");
            Console.WriteLine($"Length1 : {arrMethod.GetLength(0)}");
            Console.WriteLine($"Length1 : {tarr.GetLength(0)}, Length2 : {tarr.GetLength(1)}");

            Console.WriteLine($"index : {Array.BinarySearch<int>(arrMethod, 30)}"); 
            Console.WriteLine($"index : {Array.IndexOf(arrMethod, 50)}");

            
            Console.WriteLine($"Array.TrueForAll : {Array.TrueForAll<int>(arrMethod, passNumber)}");

            int index = Array.FindIndex<int>(arrMethod,
                delegate (int score)
                {
                    if (score >= 10)
                        return true;
                    else
                        return false;
                });
            Console.WriteLine($"index : {index}");

            arrMethod[index] = 5;

            Console.WriteLine($"Array.TrueForAll : {Array.TrueForAll<int>(arrMethod, passNumber)}");

            Array.Resize<int>(ref arrMethod, 7);
            foreach (int e in arrMethod)
                Console.Write($"{e} ");
            Console.WriteLine("");

            Array.Clear(arrMethod, 1, arrMethod.Length-1);

            foreach (int e in arrMethod)
                Console.Write($"{e} ");
            Console.WriteLine("");

            int[][] varArray = new int[2][];
            varArray[0] = new int[] { 5, 4, 3, 2, 1 };
            varArray[1] = new int[] { 3, 2, 1 };

            foreach(int[] e1 in varArray)
            {
                foreach(int e2 in e1)
                {
                    Console.Write($"{e2} ");
                }
                Console.WriteLine("");
            } 

            //print
            //30 40 50
            //60 70 80
            //90 100 110
            //10 50 30 40 20
            //30 40 50
            //Array: 1
            //Array: 2
            //Length: 5
            //Length1: 5
            //Length1: 2, Length2: 3
            //index: 2
            //index: 4
            //Array.TrueForAll : True
            //index : 0
            //Array.TrueForAll : False
            //5 20 30 40 50 0 0
            //5 0 0 0 0 0 0
            //5 4 3 2 1
            //3 2 1
        }
    }
}
