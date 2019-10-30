using System;
using System.Linq;

namespace LinqMultipleEnumeration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EnumerateWithoutToList();
            EnumerateWithToList();
        }

        private static void EnumerateWithoutToList()
        {
            var numbers = Enumerable.Range(1, 3)
                .Select(num => new { Number = num, Time = DateTime.Now.ToString("O") });

            Console.WriteLine("First Enumeration Without ToList()");
            foreach (var item in numbers)
            {
                Console.WriteLine($"Number -> {item.Number}, Time -> {item.Time}");
            }
            Console.WriteLine();

            Console.WriteLine("Second Enumeration Without ToList()");
            foreach (var item in numbers)
            {
                Console.WriteLine($"Number -> {item.Number}, Time -> {item.Time}");
            }
            Console.WriteLine();
        }

        private static void EnumerateWithToList()
        {
            var numbers = Enumerable.Range(1, 3)
                .Select(num => new { Number = num, Time = DateTime.Now.ToString("O") })
                .ToList();

            Console.WriteLine("First Enumeration With ToList()");
            foreach (var item in numbers)
            {
                Console.WriteLine($"Number -> {item.Number}, Time -> {item.Time}");
            }
            Console.WriteLine();

            Console.WriteLine("Second Enumeration With ToList()");
            foreach (var item in numbers)
            {
                Console.WriteLine($"Number -> {item.Number}, Time -> {item.Time}");
            }
            Console.WriteLine();
        }
    }
}
