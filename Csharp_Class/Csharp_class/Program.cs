using System; 

namespace Csharp_class
{
    class Dog
    {
        public string Name; 

        public string Bark()
        {
            return "Bark!!!";
        }
    }

    class Cat
    {
        public string Name;

        public Cat(string name)
        {
            Name = name;
        }
            
        public string Meow()
        {
            return "Meow~";
        }
    }

    class Person
    {
        private static int PersonCount = 0;
        private static int ConPersonParam1 = 0;
        private static int ConPersonParam2 = 0;

        public string Name = "";
        private int Age = 0;

        public Person(string name)
        {
            Name = name; 
            PersonCount++;
            ConPersonParam1++;
        }

        public Person(string name, int age) : this(name) //Run public Person(string name)
        { 
            Age = age;
            ConPersonParam2++;
        }



        public Person Clone()
        {
            Person person = new Person(this.Name, this.Age);
            return person;
        }

        public void PersonInfo()
        {
            Console.WriteLine($"Name : {Name}, Age : {Age}"); 
        }

        public static void GetPersonCount()
        {
            Console.WriteLine($"PersonCount : {PersonCount}");
            Console.WriteLine($"ConPersonParam1 : {ConPersonParam1}, ConPersonParam2 : {ConPersonParam2}");

        } 
    }

    public class AccessClass
    {
        private int AAA = 1; //클래스 내부에서만 접근 가능
        public int BBB = 2; //클래스 내부/외부 접근 가능
        protected int CCC = 3; //클래스 상속 접근 가능, 외부 접근 불가
        internal int DDD = 4; //같은 어셈블리에서 public, 다른 어셈블리에서는 private
        protected internal int EEE = 5; //같은 어셈블리에서 protected, 다른 어셈블리에서는 private
        private protected int FFF = 6;//같은 어셈블리에 있는 클래스에서 상속받은 클래스 내부에서만 접근 가능.

        public void Print()
        {
            Console.WriteLine($"{AAA}, {BBB}, {CCC}, {DDD}, {EEE}, {FFF}");
        } 
    }

    class ChiledAccessClass : AccessClass
    {
        public void Print()
        {
            //AAA (x)
            Console.WriteLine($"{BBB}, {CCC}, {DDD}, {EEE}, {FFF}");
        }
    }

    class ParentClass
    {
        protected int Money = 10000;
        public string ParentFamilyName;

        public ParentClass(string name)
        {
            ParentFamilyName = name;
        }


        public virtual void Print()
        {
            Console.WriteLine($"ParentClass : {ParentFamilyName}");
        }

        public void PrintMoney()
        {
            Console.WriteLine($"Parent money : {Money}");
        }

        public void ParentPrint()
        {
            Console.WriteLine($"ParentPrint() : {ParentFamilyName}");
        }
    } 

    class ChildClass : ParentClass
    {
        public string ChildFamilyName;

        public ChildClass(string name) : base(name)
        {
            ChildFamilyName = "child!! " + name;
        }

        public sealed override void Print()
        {
            Console.WriteLine($"ChildClass : {ChildFamilyName}");
            //base.Print();
        }

        public new void PrintMoney()
        {
            Console.WriteLine($"Child money : {Money}");
        }
    }

    class OtherClass : ChildClass
    {
        public OtherClass(string name) : base(name)
        { 
        }

        //public override void Print() { } (x)
    }

    partial class DivideClass
    {
        public static void Run1()
        {
            Console.WriteLine("Run1!!");
        }
    }

    partial class DivideClass
    { 
        public static void Run2()
        {
            Console.WriteLine("Run2!!");
        }
    }

    sealed class NewParentClass { }
    //class NewChildClass : NewParentClass { } (x) 

    public static class extenstionMethod
    {
        public static string Add(this string str, string addString)
        {
            return str + addString;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Name = "Happy";
            Console.WriteLine($"{dog.Name} : {dog.Bark()}"); //print : "Happy : Bark!!!"

            Cat cat = new Cat("Coco");
            Console.WriteLine($"{cat.Name} : {cat.Meow()}"); //print : "Coco : Meow~"

            Person man = new Person("Malone", 23);
            Person girl = new Person("IU", 22);

            man.PersonInfo(); //print : "Name : Malone, Age : 23"
            girl.PersonInfo(); //print : "Name : IU, Age : 22"
            //man.GetPersonCount(); //(X)
            Person.GetPersonCount(); //print : "PersonCount : 2"
                                     //print : "ConPersonParam1 : 2, ConPersonParam2 : 2"

            Person man2 = man;
            man2.PersonInfo(); //print : "Name : Malone, Age : 23"
            man2.Name = "Lemon";
            man.PersonInfo();  //print : "Name : Lemon, Age : 23"
            man2.PersonInfo(); ////print : "Name : Lemon, Age : 23"

            Person man3 = man.Clone();
            man3.PersonInfo(); //print : "Name : Lemon, Age : 23"
            man3.Name = "Apple";
            man.PersonInfo();  //print : "Name : Lemon, Age : 23"
            man3.PersonInfo(); //print : "Name : Apple, Age : 23"

            Person man4 = new Person("K");
            man4.PersonInfo(); //print: "Name : K, Age : 20"
            Person.GetPersonCount(); //print : "PersonCount : 4"
                                     //print : "ConPersonParam1 : 4, ConPersonParam2 : 3"

            AccessClass accessClass = new AccessClass();
            accessClass.Print(); //print : "1, 2, 3, 4, 5, 6"

            ChiledAccessClass chiledClass = new ChiledAccessClass();
            chiledClass.Print(); //print : "1, 2, 3, 4, 5"

            ParentClass parentClass = new ParentClass("Hello");
            ChildClass childClass = new ChildClass("World");

            parentClass.Print(); //print : "ParentClass : Hello"
            parentClass.PrintMoney(); //print : "Parent money : 10000"

            childClass.Print(); //print : "ChildClass : child!! World"
            childClass.PrintMoney(); //print : "Child money : 10000"
            childClass.ParentPrint(); //print : "ParentPrint() : World"

            DivideClass.Run1(); //print : "Run1!!"
            DivideClass.Run2(); //print : "Run2!!"

            string str = "Hello";
            Console.WriteLine(str.Add(" World")); //print : "Hello World"
        }
    }
}
