using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataParallelism
{
    public class Program
    {
        public static void Main()
        {
            var nums = Enumerable.Range(0, 10).ToList();

            // ParallelForEach(nums);

            ParallelFor(nums);
        }

        private static void ParallelForEach(IEnumerable<int> nums)
        {
            Parallel.ForEach(nums, (num) =>
            {
                Console.WriteLine($"Number {num} on thread: {Thread.CurrentThread.ManagedThreadId}");
            });
        }
        private static void ParallelFor(List<int> nums)
        {
            Parallel.For(0, nums.Count, (i) =>
            {
                Console.WriteLine($"Number {nums[i]} on thread: {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
