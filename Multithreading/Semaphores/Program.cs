using System;
using System.Threading;

namespace Semaphores
{
    public class Program
    {
        public static Semaphore semaphore = new Semaphore(4, 4);

        public static void Main()
        {
            while (true)
            {
                Thread.Sleep(300);
                new Thread(DoWork).Start();
            }
        }

        public static void DoWork()
        {
            semaphore.WaitOne();
            Console.WriteLine("I am working " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("End of work :) " + Thread.CurrentThread.ManagedThreadId);
            semaphore.Release();
        }
    }
}
