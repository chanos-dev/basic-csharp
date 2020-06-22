using System;
using System.Collections;

namespace Csharp_collectionAndindexer
{
    class indexerClass
    {
        int[] array = new int[3];

        public int this[int index]
        {
            get
            {
                if (index >= array.Length)
                    return -1;
                else
                    return array[index];
            }

            set
            {
                if (index >= array.Length)
                    Array.Resize<int>(ref array, index+1);

                array[index] = value;
            }
        }

        public int GetLength { get { return array.Length; } } 
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            ArrayList list = new ArrayList();

            list.Add(100);
            list.Add("chanos");
            list.Add(200);
            list.RemoveAt(1);
            list.Insert(0, 50);

            foreach (var e in list)
                Console.Write($"{e} ");
            Console.WriteLine("");

            Console.WriteLine($"List.Count : {list.Count}");
            Console.WriteLine($"List.IndexOf : {list.IndexOf(200)}");
            Console.WriteLine($"List.LastIndexOf : {list.LastIndexOf(50)}");
            list.Remove(100);

            foreach (var e in list)
                Console.Write($"{e} ");
            Console.WriteLine("");

            Queue queue = new Queue();
            for(int i = 1; i <= 5; i++)
            {
                queue.Enqueue(i*10);
            }

            Console.WriteLine($"queue.Count : {queue.Count}");

            for (int i = queue.Count - 1; i >= 0; i--)
                Console.Write($"{queue.Dequeue()} ");
            Console.WriteLine("");

            Console.WriteLine($"queue.Count : {queue.Count}");

            Stack stack = new Stack();
            stack.Push(100);
            stack.Push(200);
            stack.Push(300);
            stack.Push(400);

            IEnumerator @enum = (stack.Clone() as Stack).GetEnumerator();

            Console.WriteLine($"stack.Count : {stack.Count}");
            while (stack.Count > 0)
                Console.Write($"{stack.Pop()} ");

            Console.WriteLine("");
            Console.WriteLine($"stack.Count : {stack.Count}");
            while (@enum.MoveNext())
                Console.Write($"{@enum.Current} ");
            Console.WriteLine("");

            Hashtable hashtable = new Hashtable()
            {
                {"One", 1},
                {"Two", 2},
                {"Three", 3}
            };

            Console.WriteLine($"hashtable.Count :{hashtable.Count}");
            foreach (var e in new[] { "One", "Two", "Three", "Four" })
            {
                if(hashtable.ContainsKey(e))
                {
                    Console.Write($"{e} : {hashtable[e]} ");
                }
                else
                {
                    Console.Write($"{e} : None ");
                }
            }
            Console.WriteLine("");

            indexerClass arr = new indexerClass();

            for(int i = 0; i < arr.GetLength; i++)
            {
                arr[i] = i + 1;
            }
            arr[3] = 4;

            for (int i = 0; i < arr.GetLength; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("");

            Console.WriteLine($"{arr[4]}");

            //print
            //50 100 200
            //List.Count : 3
            //List.IndexOf : 2
            //List.LastIndexOf : 0
            //50 200
            //queue.Count : 5
            //10 20 30 40 50
            //queue.Count : 0
            //stack.Count : 4
            //400 300 200 100
            //stack.Count : 0
            //400 300 200 100
            //hashtable.Count :3
            //One: 1 Two: 2 Three: 3 Four: None
            //1 2 3 4
            //- 1
        }
    }
}
