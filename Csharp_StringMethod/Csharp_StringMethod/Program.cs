using System;
using System.Globalization;

namespace Csharp_StringMethod
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string str = "Hello Csharp.";

            Console.WriteLine($"str.indexOf(char) : {str.IndexOf('e')}"); //index = 1
            Console.WriteLine($"str.indexOf(String) : {str.IndexOf("Csharp")}"); //index = 6
            Console.WriteLine($"str.indexOf(String) : {str.IndexOf("Hi")}"); //index = -1

            Console.WriteLine($"str.LastindexOf(char) : {str.LastIndexOf('e')}"); //index = 1
            Console.WriteLine($"str.LastindexOf(String) : {str.LastIndexOf("Csharp")}"); //index = 6
            Console.WriteLine($"str.LastindexOf(String) : {str.LastIndexOf("Hi")}"); //index = -1

            Console.WriteLine($"str.StartWith(String) : {str.StartsWith("Hello")}"); //True
            Console.WriteLine($"str.StartWith(String) : {str.StartsWith("Csharp.")}"); //False

            Console.WriteLine($"str.EndsWith(String) : {str.EndsWith("Hello")}"); //True
            Console.WriteLine($"str.EndsWith(String) : {str.EndsWith("Csharp.")}"); //False

            Console.WriteLine($"str.Contains(String) : {str.Contains("sharp")}"); //True
            Console.WriteLine($"str.Contains(String) : {str.Contains("plus")}"); //False

            Console.WriteLine($"str.Replace(oldString, newString) : {str.Replace("Hello", "I Love")}"); //"I Love Csharp."

            Console.WriteLine($"str.ToLower() : {str.ToLower()}"); //"hello csharp."
            Console.WriteLine($"str.ToUpper() : {str.ToUpper()}"); //"HELLO CSHARP."

            Console.WriteLine($"str.Insert(index, String) : {str.Insert(6, "My ")}"); //"Hello My Csharp."

            Console.WriteLine($"str.Remove(start index, count) : {str.Remove(0, 6)}"); //"Csharp."


            str = " " + str + " ";
            Console.WriteLine($"str : {str}"); //" Hello Csharp. "
            Console.WriteLine($"str.Trim() : {str.Trim()}"); //"Hello Csharp."
            Console.WriteLine($"str.TrimStart() : {str.TrimStart()}"); //"Hello Csharp. "
            Console.WriteLine($"str.TrimEnd() : {str.TrimEnd()}"); //" Hello Csharp."

            str = "Hello,Csharp";
            string[] strarray = str.Split(',');
            foreach (string s in strarray)
                Console.WriteLine($"str.split(char) : {s}");
            //strarray[0] = "Hello"
            //strarray[1] = "Csharp"

            Console.WriteLine($"str.SubString(index, length) : {str.Substring(0, 5)}"); //"Hello"

            Console.WriteLine($"string.Format() : {String.Format("{0,10}", "hello")}"); //"     hello"
            Console.WriteLine($"string.Format() : {String.Format("{0,-10}", "hello")}"); //"hello     "
            Console.WriteLine($"string.Format() : {String.Format("{0:D}", 0xFF)}"); //255
            Console.WriteLine($"string.Format() : {String.Format("{0:X}", 255)}"); //FF
            Console.WriteLine($"string.Format() : {String.Format("{0:N}", 12345)}"); //12,345.00
            Console.WriteLine($"string.Format() : {String.Format("{0:N0}", 12345)}"); //12,345
            Console.WriteLine($"string.Format() : {String.Format("{0:F}", 123.45)}"); //123.45
            Console.WriteLine($"string.Format() : {String.Format("{0:E}", 100000000)}"); //1.000000E+008

            DateTime dt = new DateTime(2020, 06, 09, 02, 14, 55);
            Console.WriteLine($"{dt:yyyy-MM-dd tt hh:mm:ss dddd}"); //2020-06-09 AM 02:14:55 Tuesday

            CultureInfo ciEn = new CultureInfo("en-US");
            Console.WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (dddd)", ciEn)); //2020-06-09 AM 02:14:55 Tuesday 

        }
    }
}
