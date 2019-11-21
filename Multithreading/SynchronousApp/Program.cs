using System;
using System.Threading;

namespace SynchronousApp
{
    public class Program
    {
        public static void Main()
        {
            string input = string.Empty;

            while (true)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                input = Console.ReadLine();

                if (input == "calculate")
                {
                    LongOperation();
                }

                Console.WriteLine(input);
            }
        }

        public static void LongOperation()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
        }
    }
}
