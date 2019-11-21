using System;
using System.Threading;

namespace MultithreadingExample
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Started from Thread: " + Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 4; i++)
            {
                var thread = new Thread(() => Print());
                thread.Start();
            }
        }

        public static void Print()
        {
            Console.WriteLine("Printed from Thread Id: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
