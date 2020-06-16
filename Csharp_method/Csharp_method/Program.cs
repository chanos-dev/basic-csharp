using System;

namespace Csharp_method
{
    class Apple
    {
        private int cost = 100;

        public ref int Getcost()
        {
            return ref cost;
        } 
    }

    class MainClass
    {
        static void Print()
        {
            Console.WriteLine("Method Print()");
        }

        static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        static double Add(double num1, double num2) //overload
        {
            return num1 + num2;
        }

        static void swap(int num1, int num2)
        {
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
        }

        static void Refswap(ref int num1, ref int num2)
        {
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
        }


        static void Minus(int num1, int num2, out int outnum)
        {
            outnum = num1 - num2;
        }

        static int Sum(params int[] arr)
        {
            int sum = 0;

            foreach (int e in arr)
                sum += e;

            return sum;
        }

        static void NamedMethod(string name, int age)
        {
            Console.WriteLine($"name : {name}, age : {age}");
        }

        static int OptionalMethod(int num1, int num2 = 7)
        {
            return num1 + num2;
        }

        public static void Main(string[] args)
        {
            Print(); //print : "Method Print()"
            Console.WriteLine($"Add 5 + 5 : {Add(5, 5)}"); //print : "Add 5 + 5 : 10"
            Console.WriteLine($"Add 5.5 + 5.2 : {Add(5.5, 5.2)}"); //print : "Add 5.5 + 5.2 : 10.7
            int num1 = 250;
            int num2 = 1000;
            Console.WriteLine("swap(num1, num2)!!!");
            Console.WriteLine($"num1 : {num1}, num2 : {num2}"); //print : "num1 : 250, num2 : 1000"
            swap(num1, num2);
            Console.WriteLine($"num1 : {num1}, num2 : {num2}"); //print : "num1 : 250, num2 : 1000"
            Console.WriteLine("Refswap(ref num1, ref num2)!!!");
            Console.WriteLine($"num1 : {num1}, num2 : {num2}"); //print : "num1 : 250, num2 : 1000"
            Refswap(ref num1, ref num2);
            Console.WriteLine($"num1 : {num1}, num2 : {num2}"); //print : "num1 : 1000, num2 : 250"

            Apple apple = new Apple();
            int localCost = apple.Getcost();
            ref int ReflocalCost = ref apple.Getcost();
            
            Console.WriteLine($"localCost : {localCost}, ReflocalCost : {ReflocalCost}, Apple.cost : {apple.Getcost()}"); //print : "localCost : 100, ReflocalCost : 100, Apple.cost : 100"
            ReflocalCost = 300;
            Console.WriteLine($"localCost : {localCost}, ReflocalCost : {ReflocalCost}, Apple.cost : {apple.Getcost()}"); //print : "localCost : 100, ReflocalCost : 300, Apple.cost : 300"

            Minus(10, 5, out int minusNum);
            Console.WriteLine($"minusNum : {minusNum}"); //print : "minusNum : 5"

            Console.WriteLine($"array Sum : {Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)}"); //print : "array Sum : 55"

            NamedMethod("Yaml", 23); //print : "name : Yaml, age : 23"
            NamedMethod(age : 23, name : "Json"); //print : "name: Json, age: 23"

            Console.WriteLine($"OptionalMethod1 : {OptionalMethod(10,20)}, OptionalMethod2 : {OptionalMethod(10)}"); //print : "OptionalMethod1 : 30, OptionalMethod2 : 17"

            LocalMethod();

            void LocalMethod()
            {
                Console.WriteLine("LocalMethod!!"); //print : "LocalMethod!!"
            }
        }
    }
}
