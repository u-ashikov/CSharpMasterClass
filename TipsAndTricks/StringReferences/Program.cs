using System;

namespace StringReferences
{
    public class Program
    {
        public static void Main()
        {
            var text = "hello world";
            var secondText = "hello world";

            Console.WriteLine($"text == secondText ? -> {text == secondText}");
            Console.WriteLine($"text Equals secondText ? -> {text.Equals(secondText)}");
            Console.WriteLine($"text ReferenceEquals secondText ? -> {object.ReferenceEquals(text, secondText)}");
            Console.WriteLine();
            Console.Write("Please enter a text: ");

            var anotherText = string.Intern(Console.ReadLine());
            //var anotherText = Console.ReadLine();

            Console.WriteLine($"text == anotherText ? -> {text == anotherText}");
            Console.WriteLine($"text Equals anotherText ? -> {text.Equals(anotherText)}");
            Console.WriteLine($"text ReferenceEquals anotherText ? -> {object.ReferenceEquals(text, anotherText)}");
            Console.WriteLine();
        }
    }
}
