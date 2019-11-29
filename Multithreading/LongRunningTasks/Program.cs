using System;
using System.Threading;
using System.Threading.Tasks;

namespace LongRunningTasks
{
    public class Program
    {
        // Tasks are using the Thread Pool.
        public static void Main()
        {
            for (int i = 0; i < 100; i++)
            {
                // Slow -> By default tasks are using the Thread Pool, If you set the task to be long running, it creates new thread for this task!!!
                // Task.Run(GreetAsync);

                Task.Factory.StartNew(() => GreetAsync(), TaskCreationOptions.LongRunning);
            }

            Console.ReadLine();
        }

        public static async Task GreetAsync()
        {
            Console.WriteLine($"Hi there, I am LRT on thread => {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(20000);
        }
    }
}
