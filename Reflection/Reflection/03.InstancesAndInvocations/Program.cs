using System;
using System.Linq;
using System.Reflection;

namespace InstancesAndInvocations
{
    public class Program
    {
        public static void Main()
        {
            var catType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == nameof(Cat));

            // Create instance by calling the constructor method
            ConstructorInfo constructorToInvoke = catType.GetConstructor(new Type[] { typeof(string), typeof(int) });
            object[] constructorParameters = new object[] { "Gergan", 10 };
            ICat catInstance = constructorToInvoke.Invoke(constructorParameters) as ICat;
            Console.WriteLine(catInstance);
            Console.WriteLine(new string('=', 60));

            // Create instance with Activator.CreateInstance
            object[] parameters = new object[] { "Stoycho", 1 };
            ICat instanceWithActivator = Activator.CreateInstance(typeof(Cat), parameters) as ICat;
            Console.WriteLine(instanceWithActivator);
            Console.WriteLine(new string('=', 60));

            // Invoke Eat method
            var cat = new Cat("Stamat", 7);
            var eatMethod = cat.GetType().GetMethod("Eat", BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(eatMethod.Invoke(cat, new object[] { "Fish" }));
            Console.WriteLine(new string('=', 60));

            // Work with get and set
            var catNameProperty = cat.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
            var catName = catNameProperty.GetMethod.Invoke(cat, new object[] { });
            Console.WriteLine($"The name of the cat is: {catName}");

            var catAgeProperty = cat.GetType().GetProperty("Age", BindingFlags.Public | BindingFlags.Instance);
            var originalCatAge = cat.Age;
            catAgeProperty.SetMethod.Invoke(cat, new object[] { 100 });
            Console.WriteLine($"Original age -> {originalCatAge}, Changed age -> {cat.Age}");

            // Work with get and set with methods
            catNameProperty = cat.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
            catName = catNameProperty.GetValue(cat);
            Console.WriteLine($"Cat name: {catName}");

            catAgeProperty = cat.GetType().GetProperty("Age", BindingFlags.Public | BindingFlags.Instance);
            var anotherOriginalAge = cat.Age;
            catAgeProperty.SetValue(cat, 345);
            Console.WriteLine($"Original age -> {anotherOriginalAge}, Changed age -> {cat.Age}");
        }
    }
}
