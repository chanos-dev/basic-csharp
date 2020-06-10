using System;
using System.Collections;

namespace Csharp_TypeCastingAndOperators
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int intNum1 = 128;
            double dbNum2 = 129.14;

            long longNum3 = (long)dbNum2;
            sbyte chNum4 = (sbyte)dbNum2;

            Console.WriteLine($"longNum3 : {longNum3}"); //129
            Console.WriteLine($"chNum4 : {chNum4}"); //overflow!!

            string str1 = intNum1.ToString(); //"128"
            str1 += "0";

            int strToint = int.Parse(str1);

            str1 += ".01";
            double strTodb = Convert.ToDouble(str1);

            str1 = dbNum2.ToString();
            
            Console.WriteLine($"str1 : {str1}"); //"129.14"
            Console.WriteLine($"strToint : {strToint}"); //1280
            Console.WriteLine($"strTodb : {strTodb}"); //1280.01

            //--------------------------------------------------
            //--------------------------------------------------
            // +, -, *, /, %
            int numA = 10;
            int numB = 2;

            Console.WriteLine($"numA + numB : {numA + numB}"); //12
            Console.WriteLine($"numA - numB : {numA - numB}"); //8
            Console.WriteLine($"numA * numB : {numA * numB}"); //20
            Console.WriteLine($"numA / numB : {numA / numB}"); //5
            Console.WriteLine($"numA % numB : {numA % numB}"); //0

            // ++, --
            Console.WriteLine($"++numA : {++numA}"); //11
            Console.WriteLine($"numA++ : {numA++}"); //11
            Console.WriteLine($"numA : {numA}"); //12

            Console.WriteLine($"numA-- : {numA--}"); //12
            Console.WriteLine($"--numA : {--numA}"); //10
            Console.WriteLine($"numA : {numA}"); //10

            // <, >, ==, !=, <=, >=
            Console.WriteLine($"numA < numB : {numA < numB}"); //False
            Console.WriteLine($"numA > numB : {numA > numB}"); //True
            Console.WriteLine($"numA == numB : {numA == numB}, (numA % numB) == 0 : {(numA % numB) == 0}"); //False, True
            Console.WriteLine($"numA != numB : {numA != numB}"); //True
            Console.WriteLine($"numA <= numB : {numA <= numB}"); //False
            Console.WriteLine($"numA >= numB : {numA >= numB}"); //True

            // ?:
            int biggerNum = numA > numB ? numA : numB;
            Console.WriteLine($"numA > numB ? numA : numB : {biggerNum} "); //10

            // ?., ?[]
            ArrayList list = null;
            list?.Add("Hello"); // if (list != null) list.Add("Hello");
            list?.Add("Csharp");
            Console.WriteLine($"list.Count : {list?.Count}, list?[0] : {list?[0]}, list?[1] : {list?[1]}"); //"list.Count : , list?[0] : , list?[1] : "
            list = new ArrayList();
            list?.Add("Hello");
            list?.Add("Csharp");
            Console.WriteLine($"list.Count : {list?.Count}, list?[0] : {list?[0]}, list?[1] : {list?[1]}"); //"list.Count : 2, list?[0] : Hello, list?[1] : Csharp"

            //&&, ||, !
            bool isAnd = (numA > numB) && (numA != numB);
            bool isAnd2 = (numA > numB) && (numA == numB);
            bool isOr = (numA < numB) || (numA == numB);
            bool isOr2 = (numA > numB) || (numA == numB);
            bool isNot = !true;
            bool isNot2 = !false;

            Console.WriteLine($"isAnd : {isAnd}, isAnd2 : {isAnd2}"); //True, False
            Console.WriteLine($"isOr : {isOr}, isOr2 : {isOr2}"); //False, True
            Console.WriteLine($"isNot : {isNot}, isNot2 : {isNot2}"); //False, True

            //<<, >>, &, |, ^, ~
            int bitNum1 = 1;
            int bitNum2 = 8;
            int bitNum3 = 3;
            int bitNum4 = 5;
            sbyte bitNum5 = 127;
            Console.WriteLine($"bitNum1 : {bitNum1 << 2} "); //0000 0001 -> 0000 0100 = 1 -> 4
            Console.WriteLine($"bitNum2 : {bitNum2 >> 1}"); //0000 1000 -> 0000 0100 = 8 -> 4
            Console.WriteLine($"bitNum3 & bitNum4 : {bitNum3 & bitNum4}");//0000 0011 & 0000 0101 -> 0000 0001 = 1
            Console.WriteLine($"bitNum3 | bitNum4 : {bitNum3 | bitNum4}");//0000 0011 | 0000 0101 -> 0000 0111 = 7
            Console.WriteLine($"bitNum3 ^ bitNum4 : {bitNum3 ^ bitNum4}");//0000 0011 ^ 0000 0101 -> 0000 0110 = 6
            Console.WriteLine($"!bitNum5 : {~bitNum5}"); //0111 1111 -> 1000 0000 = -128 

            //??
            int? NullNum1 = null;
            Console.WriteLine($"NullNum1 ?? 999 : {NullNum1 ?? 999}"); //999
            NullNum1 = 123;
            Console.WriteLine($"NullNum1 ?? 999 : {NullNum1 ?? 999}"); //123
        }
    }
}
