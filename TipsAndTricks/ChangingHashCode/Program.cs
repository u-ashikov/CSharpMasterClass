using System;
using System.Collections.Generic;

namespace ChangingHashCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var catOne = new Cat(1) { Name = "Gosho" };
            var catTwo = new Cat(2) { Name = "Pesho" };
            var catThree = new Cat(3) { Name = "Gergan" };
            var catFour = new Cat(4) { Name = "Stamat" };

            // Cat - Owner
            var cats = new Dictionary<Cat, string>
            {
                { catOne, "Ivan" },
                { catTwo, "Dragan" },
                { catThree, "Slavcho" },
                { catFour, "Petko" }
            };

            var fourthCatOwner = cats[catFour];

            Console.WriteLine($"Fourth cat owner's name is {fourthCatOwner}");

            catFour.Name = "Mincho";

            fourthCatOwner = cats[catFour];

            Console.WriteLine($"Fourth cat owner's name is {fourthCatOwner}");
        }
    }
}
