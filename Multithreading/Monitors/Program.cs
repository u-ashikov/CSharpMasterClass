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
            //var threads = new List<Thread>();

            //for (int i = 0; i < 4; i++)
            //{
            //    var thread = new Thread(IncrementNumber);
            //    threads.Add(thread);

            //    thread.Start();
            //}

            //threads.ForEach(t => t.Join());

            //Console.WriteLine(Number);

            new Thread(PrepareWork).Start();

            Thread.Sleep(300);

            new Thread(DoWorkFromWorkers).Start();
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

        public static void PrepareWork()
        {
            while (true)
            {
                Monitor.Enter(obj);
                Thread.Sleep(1000);
                Console.WriteLine("I am preparing a job for you!");
                Monitor.Wait(obj);
                Console.WriteLine("I am preparing again new task for you!");
                Monitor.Exit(obj);
            }
        }

        public static void DoWorkFromWorkers()
        {
            while (true)
            {
                Monitor.Enter(obj);
                Console.WriteLine("Work in progress....");
                Thread.Sleep(1000);
                Console.WriteLine("We are done!");
                Monitor.Pulse(obj);
                Monitor.Exit(obj);
            }
        }
    }
}
