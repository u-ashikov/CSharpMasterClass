using System;
using System.Threading;

namespace ThreadsStack
{
    public class Program
    {
        public static void Main()
        {
            new Thread(() => PrintEvenNumbers()).Start();
            new Thread(() => PrintEvenNumbers()).Start();
            new Thread(() => PrintEvenNumbers()).Start();
        }

        public static void PrintEvenNumbers()
        {
            Console.WriteLine($"This is thread {Thread.CurrentThread.ManagedThreadId}, Stack Trace:");
            var stackTrace = new System.Diagnostics.StackTrace();

            Console.WriteLine(stackTrace);
            Console.WriteLine();

            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} -- > I am printing {i}");
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} -- > I am searching {i}");
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} -- > I am deleting {i}");
            }

            Thread.Sleep(15000);
        }
    }
}
