using System;

namespace Csharp_property
{
    class MainClass
    {
        class MyClass
        {
            public MyClass()
            {
                this.name = "None";
            } 

            int number;
            public int Number
            {
                get
                {
                    return number;
                }

                set
                {
                    number = value;                      
                }
            }

            string name;

            public string Name
            {
                get
                {
                    return name;
                    
                }
            }
        }

        class AutoClass
        {
            public string Info { get; set; }
            public int Number { get; set; } = 999;
        }

        interface IProduct
        {
            int Price
            {
                get;
                set;
            }
        }

        class Product
        {
            public int Price
            {
                get; set;
            }
        }

        abstract class Mammal
        {
            public string Type { get; set; }

            abstract public string Name { get; set; }
        }

        class Dog : Mammal
        {
            public override string Name { get; set; }
        }

        public static void Main(string[] args)
        {
            MyClass myclass = new MyClass();
            myclass.Number = 30;
            Console.WriteLine($"{myclass.Number}");
            Console.WriteLine($"{myclass.Name}");

            AutoClass autoClass = new AutoClass();
            autoClass.Info = "Info";
            Console.WriteLine($"{autoClass.Info}");
            Console.WriteLine($"{autoClass.Number}");

            AutoClass autoClass1 = new AutoClass()
            {
                Info = "Info2",
                Number = 980824
            };

            Console.WriteLine($"{autoClass1.Info}");
            Console.WriteLine($"{autoClass1.Number}");

            var a = new { Name = "a", Value = 12345 };

            Console.WriteLine($"{a.Name}");
            Console.WriteLine($"{a.Value}");

            Product Apple = new Product()
            {
                Price = 10000
            };

            Console.WriteLine($"{Apple.Price}");

            Dog dog = new Dog()
            {
                Name = "puppy",
                Type = "Dog"
            };

            Console.WriteLine($"{dog.Name}");
            Console.WriteLine($"{dog.Type}");

            //print
            //None
            //Info
            //999
            //Info2
            //980824
            //a
            //12345
            //10000
            //puppy
            //Dog
        }
    }
}
