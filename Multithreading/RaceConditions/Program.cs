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

            // Remove numbers from list

            // Deadlocks - project - 

            // Passing parameters to threads - project

            // Exception handling.
        }

        public static void IncrementNumber()
        {
            for (var i = 0; i < 10000; i++)
            {
                Number++;
            }

            Thread.Sleep(5000);
        }

        public static void RemoveNumbers()
        {
            while (Numbers.Count != default)
            {
                Numbers.RemoveAt(Numbers.Count-1);
            }
        }
    }
}
