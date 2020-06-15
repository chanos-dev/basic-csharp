using System;

namespace Csharp_if_switch
{
    class MainClass
    {
        enum Days { Mon, Tue, Wed, Thu, Fri, Sat, Sun, None };

        public static void Main(string[] args)
        {
            bool isTrue = true;

            if (isTrue) 
            {
                Console.WriteLine("Yes!!!"); //print : "Yes!!!"
            }

            int num1 = 5;

            if (num1 > 10) 
            {             
                Console.WriteLine("Yes!!! num1 > 10!!!");
            }
            else
            {
                Console.WriteLine("No!!! num1 < 10!!!"); //print : "No!!! num1 < 10!!!"
            }

            int grade = 87;

            if(grade >= 90)
            {
                Console.WriteLine("A");
            }
            else if(grade >= 80)
            {
                Console.WriteLine("B"); //print : "B"
            }
            else
            {
                Console.WriteLine("C");
            }

            int num2 = 100;
             
            if(num2 > 0)
            {
                if(num2 % 2 == 0)
                {
                    Console.WriteLine("num2 is even"); //print : "num2 is even"
                }
                else
                {
                    Console.WriteLine("num2 is odd");
                }
            }
            else
            {
                Console.WriteLine("num2 < 0!!!");
            }

            char ch = 'C';

            switch (ch)
            {
                case 'A':
                    Console.WriteLine("A!!!");
                    break;
                case 'B':
                    Console.WriteLine("B!!!");
                    break;
                case 'C':
                    Console.WriteLine("C!!!"); //print : "C!!!"
                    break;
            }
             
            Days days = Days.None;

            switch (days)
            {
                case Days.Mon: 
                case Days.Tue: 
                case Days.Wed: 
                case Days.Thu: 
                case Days.Fri:
                    Console.WriteLine("weekday!!");
                    break;
                case Days.Sat:
                case Days.Sun:
                    Console.WriteLine("weekend!!");
                    break;
                default:
                    Console.WriteLine("None!!"); //print: "None!!"
                    break;
            }


            object obj = 50;
            
            switch (obj)
            {
                case int i when i >= 50:
                    Console.WriteLine($"{i} is int and i >= 50"); //print: "50 is int and i >= 50"
                    break;
                case int i:
                    Console.WriteLine($"{i} is int and i < 50");
                    break;
                case float f:
                    Console.WriteLine($"{f} is floot");
                    break;
            }

        }
    }
}
