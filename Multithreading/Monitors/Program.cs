using System;
using System.Collections.Generic;
using System.Threading;

namespace Monitors
{
    public class Program
    {
        public static int Number = 0;

        public static object obj = new object();


        public static void Main()
        {
            var threads = new List<Thread>();

            for (int i = 0; i < 4; i++)
            {
                var thread = new Thread(IncrementNumber);
                threads.Add(thread);

                thread.Start();
            }

            threads.ForEach(t => t.Join());

            Console.WriteLine(Number);
        }

        public static void IncrementNumber()
        {
            Monitor.Enter(obj);

            for (int i = 0; i < 100000; i++)
            {
                Number++;
            }

            Monitor.Exit(obj);
        }
    }
}
