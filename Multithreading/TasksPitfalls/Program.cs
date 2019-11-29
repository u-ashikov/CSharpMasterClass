using System;
using System.Threading.Tasks;

namespace TasksPitfalls
{
    public class Program
    {
        public static async Task Main()
        {
            var startingMemory = GC.GetTotalMemory(false);

            for (int i = 0; i < 1000000; i++)
            {
                // 0 used
                //GetString();

                // GC.Collect is executed when the Heap is full.
                await GetStringAsync();
            }

            startingMemory = GC.GetTotalMemory(false) - startingMemory;

            Console.WriteLine(startingMemory);
        }

        public static void GetString()
        {

        }

        public static async Task GetStringAsync()
        {

        }
    }
}
