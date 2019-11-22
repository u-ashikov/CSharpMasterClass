using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RaceConditions
{
    public class Program
    {
        public static int Number = default;

        public static List<int> Numbers = Enumerable.Range(0, 10000).ToList();

        public static object obj = new object();

        public static void Main()
        {
            var threads = new List<Thread>();

            for (int i = 0; i < 4; i++)
            {
                var thread = new Thread(() =>
                {
                    //IncrementNumber();
                    RemoveNumbers();
                });

                threads.Add(thread);

                thread.Start();
            }

            threads.ForEach(t => t.Join());

            //Console.WriteLine(Number);

            //Console.WriteLine(Numbers.Count);
        }

        public static void IncrementNumber()
        {
            for (var i = 0; i < 10000; i++)
            {
                lock (obj)
                {
                    Number++;
                }
            }
        }

        public static void RemoveNumbers()
        {
            lock (obj)
            {
                while (Numbers.Count > default(int))
                {
                    Numbers.RemoveAt(Numbers.Count - 1);
                }
            }
        }
    }
}
