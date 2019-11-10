using LoadingAssemblies.Extension;
using System;
using System.Reflection;
using System.Text;

namespace LoadingAssemblies
{
    public class Program
    {
        public static void Main()
        {
            // Loading assembly with .Load(name)
            Assembly assemblyLoad = Assembly.Load("01.LoadingAssemblies");

            Assembly assemblyLoadFrom = Assembly.LoadFrom("01.LoadingAssemblies.dll");

            // Get information about the assemblies.
            Console.WriteLine($"01.LoadingAssemblies Executing Assembly: {Assembly.GetExecutingAssembly()}");
            Console.WriteLine($"01.LoadingAssemblies Calling Assembly: {Assembly.GetCallingAssembly()}");
            Console.WriteLine($"01.LoadingAssemblies Entry Assembly: {Assembly.GetEntryAssembly()}");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine(new Information().GetAssembliesInfo());
            Console.WriteLine(new string('=', 60));

            // Already loaded assemblies
            Console.WriteLine(typeof(object).Assembly.FullName);
            Console.WriteLine(typeof(StringBuilder).Assembly.FullName);
            Console.WriteLine(typeof(Information).Assembly.FullName);
            Console.WriteLine(Assembly.Load(new AssemblyName("netstandard")).FullName);
            Console.WriteLine(Assembly.Load(new AssemblyName("netstandard")).Location);
            Console.WriteLine(new string('=', 60));

            // Referenced assemblies in 01.LoadingAssemblies
            Console.WriteLine("Referenced assemblies in 01.LoadingAssemblies:");
            foreach (AssemblyName assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                Console.WriteLine($"==> {assemblyName.Name}");
            }

            Console.WriteLine(new string('=', 60));

            // Referenced assemblies in netstandard
            Console.WriteLine("Referenced assemblies in netstandard:");
            foreach (AssemblyName assemblyName in Assembly.Load("netstandard").GetReferencedAssemblies())
            {
                Console.WriteLine($"==> {assemblyName.Name}");
            }
            Console.WriteLine(new string('=', 60));
        }
    }
}
