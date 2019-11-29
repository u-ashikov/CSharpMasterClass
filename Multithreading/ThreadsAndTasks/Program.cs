using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAndTasks
{
    public class Program
    {
        public static async Task Main()
        {
            DoWork();
            await Task.Run(DoWorkAsync);
            Console.ReadLine();
        }

        public static async Task Greet()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Hello");
        }

        public static async Task DoWorkAsync()
        {
            Console.WriteLine($"Before Await ->  DoWorkAsync Thread: {Thread.CurrentThread.ManagedThreadId}");

            await Task.Run(DoWork);

            Console.WriteLine($"After Await -> DoWorkAsync Thread: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("I am async method and I will do some work for you!");
        }

        public static void DoWork()
        {
            Console.WriteLine("I am sync method and I will sleep the thread!");

            Thread.Sleep(1000);

            Console.WriteLine($"DoWork Thread: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
