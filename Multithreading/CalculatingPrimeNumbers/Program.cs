using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CalculatingPrimeNumbers
{
    public class Program
    {
        public static void Main()
        {
            // Calculate sequentially
            var executionTimes = 6;
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < 1; i++)
            {
                CalculatePrimes();
            }

            stopWatch.Stop();
            Console.WriteLine($"Sequentially calculation: {stopWatch.ElapsedMilliseconds}");
            stopWatch.Reset();

            var threads = new List<Thread>();

            stopWatch.Start();

            for (int i = 0; i < executionTimes; i++)
            {
                threads.Add(new Thread(() => CalculatePrimes()));
                threads[i].Start();
            }

            threads.ForEach(t => t.Join());

            stopWatch.Stop();
            Console.WriteLine($"Using threads calculation: {stopWatch.ElapsedMilliseconds}");
        }

        public static void CalculatePrimes()
        {
            var isPrime = true;
            var number = 1000000;

            for (int i = 0; i < number; i++)
            {
                for (int p = 2; p < number; p++)
                {
                    if (i % p == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }
        }
    }
}
