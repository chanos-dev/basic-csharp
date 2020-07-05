using System;

namespace Csharp_dynamic
{
    interface IPrint
    {
        void Func1();
    }

    class Foo : IPrint
    {
        public virtual void Func1()
        {
            Console.WriteLine("Foo, Func1");
        }
    }

    class Boo : Foo
    {
        public override void Func1()
        {
            Console.WriteLine("Boo, Func1");
        }
    }

    class Roo
    {
        public void Func1()
        {
            Console.WriteLine("Roo, Func1");
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            IPrint[] prints = new IPrint[] { new Foo(), new Boo() };

            foreach (IPrint p in prints)
                p.Func1();

            dynamic[] prints2 = new dynamic[] { new Foo(), new Boo(), new Roo() };

            foreach (dynamic d in prints2)
                d.Func1(); 
        }
    }
}