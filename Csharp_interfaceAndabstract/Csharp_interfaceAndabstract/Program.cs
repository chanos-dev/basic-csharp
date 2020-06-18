using System;
using System.Globalization;

namespace Csharp_interfaceAndabstract
{
    interface ILogger
    {
        void WriteLog(string log);
    }

    interface IDateLogger : ILogger
    {
        void WriteDateLog(string date);
    }

    interface IRun
    {
        void Run();
    }

    interface IFly
    {
        void Fly();
    }

    class Computer : ILogger
    {
        public void WriteLog(string log)
        {
            Console.WriteLine($"Computer Log : {log}");
        }
    }

    class KeyboardLog : ILogger
    {
        public void WriteLog(string log)
        {
            Console.WriteLine($"Keyboard Log : {log}");
        }
    }

    class Monitor
    {
        public ILogger logger;

        public Monitor(ILogger logger)
        {
            this.logger = logger;
        }

        public void writeLog(string log)
        {
            logger.WriteLog(log);
        }
    }

    class Calendar : IDateLogger
    {
        public void WriteLog(string log)
        {
            Console.WriteLine($"Calendar Log : {log}");
        }

        public void WriteDateLog(string date)
        {
            Console.WriteLine($"Calendar DateLog : {date}");
        }
    }

    class Duck : IRun, IFly
    {
        public void Run()
        {
            Console.WriteLine("Run!!");
        }

        public void Fly()
        {
            Console.WriteLine("Fly!!");
        }
    }

    interface IPrint
    {
        void Print();
    }

    abstract class mammal
    {
        private string name;

        public mammal(string name)
        {
            this.name = name;
        } 

        protected void type()
        {
            Console.WriteLine($"{name} : mammal!");
            Sound();
        }

        public abstract void Sound();
    }

    class Tiger : mammal, IPrint
    {
        public Tiger(string name) : base(name) { }

        public override void Sound()
        { 
            Console.WriteLine("Tiger growl..");
        }

        public void Print()
        {
            base.type();
        }
    }

    class Lion : mammal, IPrint
    {
        public Lion(string name) : base(name) { }

        public override void Sound()
        { 
            Console.WriteLine("Lion growl..");
        }

        public void Print()
        {
            base.type();
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Computer computer = new Computer();
            computer.WriteLog("test log!!");

            Monitor monitor = new Monitor(new KeyboardLog());
            monitor.writeLog("monitor log!!");

            monitor.logger = computer;
            monitor.writeLog("monitor log!!");

            Calendar calendar = new Calendar();
            calendar.WriteLog("calendar log!!");

            CultureInfo ciEn = new CultureInfo("en-US"); 
            DateTime dt = new DateTime(2020, 06, 19, 01, 10, 20);
            calendar.WriteDateLog(dt.ToString("yyyy-MM-dd tt hh:mm:ss dddd",ciEn));

            Duck duck = new Duck();
            duck.Run();
            duck.Fly();

            IRun run = duck as IRun;
            run.Run();

            IFly fly = duck as IFly;
            fly.Fly();

            Tiger tiger = new Tiger("Tiger");
            Lion lion = new Lion("Lion");

            IPrint[] print = { tiger, lion };

            foreach (var e in print)
                e.Print();

            //print
            //Computer Log : test log!!
            //Keyboard Log: monitor log!!
            //Computer Log: test log!!
            //Keyboard Log: monitor log!!
            //Computer Log: test log!!
            //Keyboard Log: monitor log!!
            //Computer Log: monitor log!!
            //Calendar Log: calendar log!!
            //Calendar DateLog: 2020 - 06 - 19 AM 01:10:20 Friday
            //Run!!
            //Fly!!
            //Run!!
            //Fly!!
            //Tiger : mammal!
            //Tiger growl..
            //Lion : mammal!
            //Lion growl..
        }
    }
}
