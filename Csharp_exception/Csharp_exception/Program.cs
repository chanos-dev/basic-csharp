using System;

namespace Csharp_exception
{
    class IsEmptyString : Exception
    {
        public IsEmptyString() { }
        public IsEmptyString(string msg) : base(msg) { }

        public string CustomMessage { get; set; }

        public int ErrorCode { get; set; }
    }


    class MainClass
    {
        public static void Print(string value)
        {
            if (value.Trim() == "")
                throw new Exception("String is empty!!");

            Console.WriteLine(value);
        }
        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            try
            {
                Console.Write($"{arr[3]}");
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Index Error!!");
            }

            try
            {
                throw new Exception("throw Exception!!");
            }
            catch(Exception e)
            {
                Console.WriteLine($"catch : {e.Message}");
            }

            try
            {
                Print("Hello Exception~!");
                Print("");
            }
            catch(Exception e)
            {
                Console.WriteLine($"catch : {e.Message}");
            }

            try
            {
                throw new IsEmptyString()
                {
                    CustomMessage = "Custom throw Exception!!",
                    ErrorCode = 401
                };
            }
            catch(IsEmptyString e)
            {
                Console.WriteLine($"catch : {e.Message}");
                Console.WriteLine($"Argument : {e.CustomMessage}, {e.ErrorCode}");
            }

            try
            {
                throw new IsEmptyString("IsArguments Exception!!")
                {
                    CustomMessage = "Custom throw Exception!!",
                    ErrorCode = 251
                };
            }
            catch (IsEmptyString e) when (e.ErrorCode > 200 && e.ErrorCode < 300)
            {
                Console.WriteLine($"catch : {e.Message}");
                Console.WriteLine($"Argument : {e.CustomMessage}, {e.ErrorCode}");
                Console.WriteLine("when (e.ErrorCode > 200 && e.ErrorCode < 300)");
            }
            catch (IsEmptyString e) when (e.ErrorCode > 400 && e.ErrorCode < 500)
            {
                Console.WriteLine($"catch : {e.Message}");
                Console.WriteLine($"Argument : {e.CustomMessage}, {e.ErrorCode}");
                Console.WriteLine("when (e.ErrorCode > 400 && e.ErrorCode < 500)");
            }
        }
    }
}
