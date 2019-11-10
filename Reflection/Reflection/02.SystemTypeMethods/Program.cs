using System;
using System.Linq;
using System.Reflection;

namespace SystemTypeMethods
{
    public class Program
    {
        public static void Main()
        {
            Type catType = typeof(Cat);

            // Type Info
            Console.WriteLine($"FullName: {catType.FullName}");
            Console.WriteLine($"Namespace: {catType.Namespace}");
            Console.WriteLine($"Name: {catType.Name}");
            Console.WriteLine($"Assembly FullName: {catType.Assembly.FullName}");
            Console.WriteLine($"Base Type: {catType.BaseType}");
            Console.WriteLine($"Is Abstract: {catType.IsAbstract}");
            Console.WriteLine($"Is Interface: {catType.IsInterface}");
            Console.WriteLine($"Interfaces: {string.Join(", ", catType.GetInterfaces().ToList())}");
            Console.WriteLine(new string('=', 60));

            // Fields Info
            FieldInfo nullField = catType.GetField("age");
            Console.WriteLine($"Searching for age field => {(nullField == null ? "No Fields Found" : nullField.ToString())}");
            FieldInfo privateField = catType.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine($"Searching for non-public field age => {privateField}");
            FieldInfo[] allFields = catType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine($"All Fields => {string.Join(Environment.NewLine, allFields.ToList())}");
            Console.WriteLine(new string('=', 60));

            // Methods Info
            MethodInfo introduceMethod = catType.GetMethod("IntroduceYourself");
            Console.WriteLine($"Searching for public IntroduceYourself method: {introduceMethod}");
            MethodInfo obsoleteMethod = catType.GetMethod("ObsoleteMethod", BindingFlags.Static | BindingFlags.Public);
            Console.WriteLine($"Searching for static Obsolete method: {obsoleteMethod}");
            MethodInfo[] allMethods = catType.GetMethods();
            Console.WriteLine($"All Methods => {string.Join(Environment.NewLine, allMethods.ToList())}");
            Console.WriteLine(new string('=', 60));

            // Properties Info
            PropertyInfo colorProperty = catType.GetProperty("Color");
            Console.WriteLine($"Searching for Color property => {colorProperty}");
            PropertyInfo protectedInternalProperty = catType.GetProperty("MyProtectedInternalProperty", BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine($"Searching for Protected Internal Property => {protectedInternalProperty}");
            PropertyInfo[] allProperties = catType.GetProperties();
            Console.WriteLine($"All Public Properties => {string.Join(Environment.NewLine, allProperties.ToList())}");
            Console.WriteLine(new string('=', 60));

            // Constructors Info
            ConstructorInfo constructorInfo = catType.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string)});
            Console.WriteLine($"Searching for .ctor(string name, int age, string color) => {constructorInfo}");
            ConstructorInfo protectedConstructor = catType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, binder: null, new Type[] { }, null);
            Console.WriteLine($"Searching for protected .ctor() => {protectedConstructor}");
            ConstructorInfo[] allConstructors = catType.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            Console.WriteLine($"All Constructors => {string.Join(Environment.NewLine, allConstructors.ToList())}");
            Console.WriteLine(new string('=', 60));

            // Members Info
            MemberInfo[] allMembers = catType.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            Console.WriteLine("All Members:");
            foreach (var member in allMembers)
            {
                Console.WriteLine($"==> {member.Name} - {member.DeclaringType}");
            }
            Console.WriteLine(new string('=', 60));

            // Member with specific attribute
            var membersWithObsoleteAttribute = catType.GetMembers(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(m => m.GetCustomAttributes(typeof(ObsoleteAttribute)).Any())
                            .ToList();

            Console.WriteLine($"Members with attribute => {string.Join(Environment.NewLine, membersWithObsoleteAttribute.ToList())}");
            Console.WriteLine(new string('=', 60));
        }
    }
}
