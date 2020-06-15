using System;

namespace Csharp_Loop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int i;
            for (i = 0; i < 5; i++)
                Console.WriteLine($"for(i) : {i}");
            //print
            //for (i) : 0
            //for (i) : 1
            //for (i) : 2
            //for (i) : 3
            //for (i) : 4

            for (int j = 4; j >= 0; j--)
                Console.WriteLine($"for(j) : {j}");
            //print
            //for (j) : 4
            //for (j) : 3
            //for (j) : 2
            //for (j) : 1
            //for (j) : 0

            for (i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    Console.WriteLine($"for(i),(j) : {i},{j}");
            //print
            //for (i),(j) : 0,0
            //for (i),(j) : 0,1
            //for (i),(j) : 1,0
            //for (i),(j) : 1,1

            i = 10;
            while(i > 0)
            {
                Console.WriteLine($"while(i) : {i}");
                i--;
            }
            //print 
            //while (i) : 10
            //while (i) : 9
            //while (i) : 8
            //...
            //while (i) : 3
            //while (i) : 2
            //while (i) : 1

            i = 10;
            do
            {
                Console.WriteLine($"do while(i) : {i}");
                i -= 2;
            } while (i > 0);
            //print
            //while (i) : 10
            //while (i) : 8
            //while (i) : 6
            //while (i) : 4
            //while (i) : 2

            int[] intArr = new[] { 10, 20, 30, 40, 50 };
            foreach (int e in intArr)
                Console.WriteLine($"foreach e : {e}");
            //print
            //foreach e : 10
            //foreach e : 20
            //foreach e : 30
            //foreach e : 40
            //foreach e : 50
        }
    }
}
