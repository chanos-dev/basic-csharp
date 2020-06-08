using System;

namespace Csharp_DataTypes
{
    class MainClass
    {
        enum checkFlag { Yes, No }; //default = 0, 1, ...~
        enum checkFlag2 { Yes = 10, No = 20};

        public static void Main(string[] args)
        {
            byte bt; //1byte  
            Console.WriteLine($"Byte Min : {byte.MinValue}, Max : {byte.MaxValue}");

            sbyte sbt; //1byte  
            Console.WriteLine($"sByte Min : {sbyte.MinValue}, Max : {sbyte.MaxValue}");

            short sh; //2byte  
            Console.WriteLine($"short Min : {short.MinValue}, Max : {short.MaxValue}");

            ushort ush; //2byte  
            Console.WriteLine($"ushort Min : {ushort.MinValue}, Max : {ushort.MaxValue}");

            int it; //4byte
            Console.WriteLine($"int Min : {int.MinValue}, Max : {int.MaxValue}");

            uint uit; //4byte
            Console.WriteLine($"uint Min : {uint.MinValue}, Max : {uint.MaxValue}");

            long lo; //8byte
            Console.WriteLine($"long Min : {long.MinValue}, Max : {long.MaxValue}");

            ulong ulo; //8byte
            Console.WriteLine($"ulong Min : {ulong.MinValue}, Max : {ulong.MaxValue}");

            float fl; //4byte
            Console.WriteLine($"float Min : {float.MinValue}, Max : {float.MaxValue}");

            double db; //8byte
            Console.WriteLine($"double Min : {double.MinValue}, Max : {double.MaxValue}");

            decimal dc; //16byte
            Console.WriteLine($"decimal Min : {decimal.MinValue}, Max : {decimal.MaxValue}");

            char ch; //character
            ch = 'A';
            Console.WriteLine($"char : {ch}");

            string str;
            str = "Hello Csharp!!";
            Console.WriteLine($"string : {str}");

            bool isbool; //1byte
            isbool = true; //or false;
            Console.WriteLine($"bool : {isbool}");

            object obj, obj2, obj3;
            obj = 1234;
            obj2 = 8.24;
            obj3 = "string object";
            Console.WriteLine($"Object : {obj}, {obj2}, {obj3}");

            const double Pi = 3.14;
            // Pi = 1.11; (x)
            Console.WriteLine($"Pi : {Pi}");


            checkFlag flg = checkFlag.Yes;
            Console.WriteLine($"Enum : {flg}");

            checkFlag2 flg2 = checkFlag2.No;
            Console.WriteLine($"Enum2 : {(int)flg2}");


            //nullable
            int? nullint = null;
            Console.WriteLine($"Nullable.HasValue : {nullint.HasValue}");

            nullint = 88;
            Console.WriteLine($"Nullable.HasValue : {nullint.HasValue}");
            if (nullint.HasValue)
                Console.WriteLine($"Nullable.Value : {nullint.Value}");

            var var1 = 3;
            var var2 = 3.14;
            var var3 = 'B';
            var var4 = "Hello var type";

            Console.WriteLine($"var : {var1}, {var2}, {var3}, {var4}"); 
        }
    }
}
