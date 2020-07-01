using System;
using System.Linq;

namespace Csharp_LINQ
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public int[] Grade { get; set; }
        public int Height { get; set; }

        public Student(string name, int height, int[] grade)
        {
            Name = name;
            Height = height;
            Grade = grade;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Person[] people =
            {
                new Person("Mike", 44),
                new Person("Jason", 31),
                new Person("Jake", 22),
                new Person("Peter", 15),
                new Person("Jessica", 29)
            };

            var personInfo = from human in people
                             where human.Age > 25
                             orderby human.Age descending
                             select human;

            foreach (var person in personInfo)
                Console.WriteLine($"Name : {person.Name}, Age : {person.Age}");


            int[] number = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var even_number = from num in number
                              where num % 2 == 0
                              orderby num
                              select num;

            foreach (var e in even_number)
                Console.Write($"{e} ");
            Console.WriteLine("");


            var personInfo2 = from human in people
                             where (human.Age > 25) && (human.Name[0] == 'J')
                             orderby human.Age 
                             select human;

            foreach (var person in personInfo2)
                Console.WriteLine($"Name : {person.Name}, Age : {person.Age}");


            var odd_number = from num in number
                             where num % 2 == 1
                             orderby num
                             select new { oddNumber = num, square = num * num };

            foreach (var e in odd_number)
                Console.WriteLine($"oddNumber : {e.oddNumber}, square : {e.square} ");


            Student[] students =
            {
                new Student("Mike", 170, new int[] {90, 80, 70 }),
                new Student("Jason",165, new int[] {55, 15, 30 }),
                new Student("Jake", 188, new int[] {90, 96, 100 }),
                new Student("Peter", 161, new int[] {66, 70, 65 }),
                new Student("Jessica", 155, new int[] {20, 30, 70 })
            };


            var student_grade = from student in students
                                from grade in student.Grade
                                where grade < 60
                                select new { student.Name, Score = grade };

            foreach (var student in student_grade)
                Console.WriteLine($"Name : {student.Name}, Score : {student.Score}");

            var student_height = from student in students 
                                group student by student.Height < 170 into g
                                select new { GroupKey = g.Key, Student = g };

            foreach (var group in student_height)
            {
                Console.WriteLine($"- student.Height < 170 : {group.GroupKey}");
                foreach(var student in group.Student)
                {
                    Console.WriteLine($"\t Name : {student.Name}, Height : {student.Height}");
                }
            }

            var odd_number2 = number.Where(e => e % 2 == 1).OrderBy(e => e).Select(e => new { oddNumber = e, square = e * e });
            foreach(var e in odd_number2)
                Console.WriteLine($"oddNumber : {e.oddNumber}, square : {e.square} ");
        }
    }
}
