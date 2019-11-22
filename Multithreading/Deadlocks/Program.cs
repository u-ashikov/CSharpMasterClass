using System;
using System.Collections.Generic;
using System.Threading;

namespace Deadlocks
{
    public class Program
    {
        public static int Number = 0;

        public static object FirstObject = new object();

        public static object SecondObject = new object();

        public static void Main()
        {
            var threads = new List<Thread>();

            var firstThread = new Thread(FirstDeadlock);
            var secondThread = new Thread(SecondDeadLock);

            threads.Add(firstThread);
            threads.Add(secondThread);

            firstThread.Start();
            secondThread.Start();

            threads.ForEach(t => t.Join());

            Console.WriteLine(Number);
        }

        public static void FirstDeadlock()
        {
            lock (FirstObject)
            {
                Console.WriteLine("Thread 1 got locked!");
                Thread.Sleep(1000);
                lock (SecondObject)
                {
                    Console.WriteLine("Thread 2 got locked!");
                    Number++;
                }
            }
        }

        public static void SecondDeadLock()
        {
            lock (SecondObject)
            {
                Console.WriteLine("Thread 2 got locked!");
                Thread.Sleep(1000);
                lock (FirstObject)
                {
                    Console.WriteLine("Thread 1 got locked!");
                    Number++;
                }
            }
        }
    }
}
