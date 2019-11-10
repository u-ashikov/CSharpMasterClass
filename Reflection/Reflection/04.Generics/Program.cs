using System;
using System.Reflection;

namespace Generics
{
    public class Program
    {
        public static void Main()
        {
            // Instance of generic class
            var dbSetType = typeof(DbSet<>);
            var genericType = dbSetType.MakeGenericType(new Type[] { typeof(Cat) });
            var instance = Activator.CreateInstance(genericType, new object[] { }) as DbSet<Cat>;
            instance.Add(new Cat());
            instance.Add(new Cat());
            instance.Add(new Cat());

            Console.WriteLine(instance.Count);
            Console.WriteLine(new string('=', 60));

            // Invocation of generic method
            var catType = typeof(Cat);
            var genericMethodType = catType.GetMethod("WhoAmI", BindingFlags.Public | BindingFlags.Instance);
            var genericMethod = genericMethodType.MakeGenericMethod(new Type[] { typeof(string) });
            Console.WriteLine(genericMethod.Invoke(new Cat(), new object[] { "Hello" }));
            Console.WriteLine(new string('=', 60));
        }
    }
}
