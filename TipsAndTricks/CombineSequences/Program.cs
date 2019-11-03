using System;
using System.Collections.Generic;
using System.Linq;

namespace CombineSequences
{
    public class Program
    {
        public static void Main()
        {
            var firstList = new List<string>() { "apple", "banana", "cherry", "dragon fruit", "eggplant" };
            var secondList = new List<string>() { "banana", "cherry", "dragon fruit", "mushroom" };

            Console.WriteLine("===== Concatenate =====");
            var concatenatedList = firstList.Concat(secondList);
            Console.WriteLine(string.Join(", ", concatenatedList));
            Console.WriteLine();

            Console.WriteLine("===== Intersect =====");
            var intersectedList = firstList.Intersect(secondList);
            Console.WriteLine(string.Join(", ", intersectedList));
            Console.WriteLine();

            Console.WriteLine("===== Except =====");
            var exceptList = firstList.Except(secondList);
            Console.WriteLine(string.Join(", ", exceptList));
            Console.WriteLine();

            Console.WriteLine("===== Union =====");
            var unionList = firstList.Union(secondList);
            Console.WriteLine(string.Join(", ", unionList));
            Console.WriteLine();
        }
    }
}
