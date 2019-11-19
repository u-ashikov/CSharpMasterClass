using Common;
using System;

namespace DynamicExample
{
    public class Program
    {
        public static void Main()
        {
            var cat = new Cat("Pesho", 10);

            dynamic exposedObject = cat.Expose();

            var propValue = exposedObject.SomeImportantProp;
            var fieldValue = exposedObject.ImportantField;

            Console.WriteLine(propValue);
            Console.WriteLine(fieldValue);
        }
    }
}
