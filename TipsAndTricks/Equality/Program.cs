using System;

namespace Equality
{
    public class Program
    {
        public static void Main()
        {
            int firstNum = 10;
            int secondNum = 10;

            Console.WriteLine($"firstNum == secondNum ? -> {firstNum == secondNum}");
            Console.WriteLine($"firstNum Equals secondNum ? -> {firstNum.Equals(secondNum)}");
            Console.WriteLine();

            int[] arrayX = new int[] { 1, 2, 3 };
            int[] arrayY = new int[] { 1, 2, 3 };

            Console.WriteLine($"arrayX == arrayY ? -> {arrayX == arrayY}");
            Console.WriteLine($"arrayX Equals arrayY ? -> {arrayX.Equals(arrayY)}");
            Console.WriteLine($"arrayX ReferenceEquals arrayY ? -> {object.ReferenceEquals(arrayX, arrayY)}");
            Console.WriteLine();

            int[] arrayZ = arrayX;

            Console.WriteLine($"arrayX == arrayZ ? -> {arrayX == arrayZ}");
            Console.WriteLine($"arrayX Equals arrayZ ? -> {arrayX.Equals(arrayZ)}");
            Console.WriteLine($"arrayX ReferenceEquals arrayZ ? -> {object.ReferenceEquals(arrayX, arrayZ)}");
            Console.WriteLine();

            var catX = new Cat("Gosho", 10, "red");
            var catY = new Cat("Gosho", 10, "red");

            Console.WriteLine($"catX == catY ? -> {catX == catY}");
            Console.WriteLine($"catX Equals catY ? -> {catX.Equals(catY)}");
            Console.WriteLine();

            var catStructX = new CatStruct("Gosho", 10, "red");
            var catStructY = new CatStruct("Gosho", 10, "red");

            Console.WriteLine($"catStructX Equals catStructY ? -> {catStructX.Equals(catStructY)}");
            Console.WriteLine($"catStructX ReferenceEquals catStructY ? -> {object.ReferenceEquals(catStructX, catStructY)}");
            Console.WriteLine();

            CompareObjects(catX, catY);

            var catWithEqualsX = new CatWithEquals("Gosho", 10, "red");
            var catWithEqualsY = new CatWithEquals("Gosho", 10, "red");

            Console.WriteLine($"catWithEqualsX == catWithEqualsY ? -> {catWithEqualsX == catWithEqualsY}");
            Console.WriteLine($"catWithEqualsX Equals catWithEqualsY ? -> {catWithEqualsX.Equals(catWithEqualsY)}");
            Console.WriteLine();

            CompareObjects(catWithEqualsX, catWithEqualsY);

            var catWithEqualityOperatorX = new CatWithEqualityOperator("Gosho", 10, "red");
            var catWithEqualityOperatorY = new CatWithEqualityOperator("Gosho", 10, "red");

            Console.WriteLine($"catWithEqualityOperatorX == catWithEqualityOperatorY ? -> {catWithEqualityOperatorX == catWithEqualityOperatorY}");
            Console.WriteLine($"catWithEqualityOperatorX Equals catWithEqualityOperatorY ? -> {catWithEqualityOperatorX.Equals(catWithEqualityOperatorY)}");
            Console.WriteLine();

            CompareObjects(catWithEqualityOperatorX, catWithEqualityOperatorY);
        }

        private static void CompareObjects<T>(T firstObject, T secondObject)
            where T : class
        {
            Console.WriteLine(
                "f{1} == s{2} is {0}",
                firstObject == secondObject,
                firstObject.GetType().Name,
                secondObject.GetType().Name);
            Console.WriteLine(
                "f{1}.Equals(s{2}) is {0}",
                firstObject.Equals(secondObject),
                firstObject.GetType().Name,
                secondObject.GetType().Name);
            Console.WriteLine(
                "ReferenceEquals(f{1}, s{2}) is {0}",
                object.ReferenceEquals(firstObject, secondObject),
                firstObject.GetType().Name,
                secondObject.GetType().Name);
            Console.WriteLine();
        }
    }
}
