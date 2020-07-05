using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Csharp_reflectionAndattribute
{
    class Profile
    {
        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        public Profile()
        {
            name = "";
            phone = "";
        }

        public Profile(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }

        public void Print()
        {
            Console.WriteLine($"{name}, {phone}");
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            int a = 0;

            Type type = a.GetType();

            PrintInterface(type);
            Console.WriteLine("");
            PrintFields(type);
            Console.WriteLine("");
            PrintMethods(type);
            Console.WriteLine("");
            PrintProperties(type);


            type = Type.GetType("Csharp_reflectionAndattribute.Profile");
            MethodInfo methodinfo = type.GetMethod("Print");
            PropertyInfo nameProperty = type.GetProperty("Name");
            PropertyInfo phoneProperty = type.GetProperty("Phone");

            object profile = Activator.CreateInstance(type, "Jessica", "010-1234-1234");
            methodinfo.Invoke(profile, null);

            profile = Activator.CreateInstance(type);
            nameProperty.SetValue(profile, "Mike", null);
            phoneProperty.SetValue(profile, "010-4321-4321", null);

            Console.WriteLine($"{nameProperty.GetValue(profile, null)}, {phoneProperty.GetValue(profile, null)}");
            methodinfo.Invoke(profile, null);

            OldMethod();
            NewMedtohd();

            type = typeof(Myclass);

            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            foreach(Attribute e in attributes)
            {
                Console.WriteLine($"{e.ToString()}");
                History history = e as History;

                if(history != null)
                {
                    Console.WriteLine($"{history.Programmer}, {history.Version}, {history.Changes}");   
                }
            }
        }

        private static void PrintInterface(Type type)
        {
            Type[] _interface = type.GetInterfaces();

            foreach (Type i in _interface)
                Console.WriteLine($"{i.Name}");
        }

        private static void PrintFields(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            foreach (FieldInfo e in fields)
            {
                string accessLevel = "protected";
                if (e.IsPublic) accessLevel = "public";
                else if (e.IsPrivate) accessLevel = "private";

                Console.WriteLine($"Access : {accessLevel}, Type : {e.FieldType.Name}, Name : {e.Name}");
            }
        }

        private static void PrintMethods(Type type)
        {
            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo e in methods)
            {
                Console.Write($"Type : {e.ReturnType.Name}, Name : {e.Name}, Parameter : ");

                ParameterInfo[] parameters = e.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name}");
                    if (i < parameters.Length - 1)
                        Console.Write(", ");
                }
                Console.WriteLine("");
            }
        }

        private static void PrintProperties(Type type)
        {
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo e in properties)
                Console.WriteLine($"Type : {e.PropertyType.Name}, Name : {e.Name}");

        }


        [Obsolete("Please use NewMethod().")]
        public static void OldMethod()
        {
            Console.WriteLine("Old");
        }

        public static void NewMedtohd([CallerFilePath] string path = "", [CallerLineNumber] int line = 0, [CallerMemberName] string member = "")
        {
            Console.WriteLine($"New - {path}, {line}, {member}");
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        class History : Attribute
        {
            private string programmer;

            public double Version { get; set; }
            public string Changes { get; set; }
            public History(string programmer)
            {
                this.programmer = programmer;
                Version = 1.0;
                Changes = "First release";
            }

            public string Programmer
            {
                get { return programmer; }
            }

            public override string ToString()
            {
                return $"ToString() {programmer}, {Version}, {Changes}";
            }
        }

        [History("Mike", Version = 0.1, Changes = "2020-07-05 Created class")]
        [History("Jessica", Version = 0.2, Changes = "2020-07-05 Modified class")]
        class Myclass
        {
            public void Func()
            {
                Console.WriteLine("Func()");
            }
        }
    }
}