using System;

namespace Csharp_structAndtuple
{
    class MainClass
    {
        struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void print()
            {
                Console.WriteLine($"x : {x}, y: {y}");
            } 
        }

        public static (int add, int minus) AddAndMinus(int num1, int num2)
        {
            int add = num1 + num2;
            int minus = num1 - num2;

            return (add, minus);
        }

        public static void Main(string[] args)
        {
            Point point = new Point(10, 20);
            point.print();
            Point point2 = point;
            point2.x--;
            point2.y++;
            point.print();
            point2.print();

            var tuple1 = ("Json", 50);
            Console.WriteLine($"Name : {tuple1.Item1}, Age : {tuple1.Item2}");

            var tuple2 = (Name:"Xml", Age:65);
            Console.WriteLine($"Name : {tuple2.Name}, Age : {tuple2.Age}");
            tuple2.Age++;

            (string name, int age) = tuple2;
            Console.WriteLine($"Name : {name}, Age : {age}");

            var tuple3 = AddAndMinus(20, 30);
            Console.WriteLine($"Add : {tuple3.add}, Minus : {tuple3.minus}");

            (int add, _) = tuple3;
            Console.WriteLine($"Add : {add}");


            //print
            //x: 10, y: 20
            //x: 9, y: 21
            //Name: Json, Age: 50
            //Name: Xml, Age: 65
            //Name: Xml, Age: 66
            //Add: 50, Minus: -10
            //Add: 50
        }
    }
}
