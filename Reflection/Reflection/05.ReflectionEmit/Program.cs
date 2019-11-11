using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ReflectionEmit
{
    public class Program
    {
        private const string AssemblyName = "HelloStudents.dll";

        public static void Main()
        {
            var assemlby = AssemblyBuilder.DefineDynamicAssembly(
                new AssemblyName(AssemblyName),
                AssemblyBuilderAccess.RunAndCollect);

            var module = assemlby.DefineDynamicModule(AssemblyName);

            CreateHelloStudentsMethod(module);
            CreateSumMethod(module);
            ReadAndGreet(module);

            module.CreateGlobalFunctions();

            module.GetMethod("GreetStudents").Invoke(null, null);
            Console.WriteLine(module.GetMethod("CalculateSum").Invoke(null, new object[] { 100, 200 }));
            module.GetMethod("ReadAndGreet").Invoke(null, null);
        }

        private static void CreateHelloStudentsMethod(ModuleBuilder module)
        {
            var methodBuilder = module.DefineGlobalMethod(
                            "GreetStudents",
                            MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Static,
                            typeof(void),
                            null
                            );

            var ilGenerator = methodBuilder.GetILGenerator();

            var writeLineMethod = typeof(Console).GetMethod(
                "WriteLine",
                BindingFlags.Public | BindingFlags.Static, 
                Type.DefaultBinder,
                new[] { typeof(string) },
                null);

            ilGenerator.Emit(OpCodes.Ldstr, "Hello, Students!");
            ilGenerator.EmitCall(OpCodes.Call, writeLineMethod, new[] { typeof(string) });
            ilGenerator.Emit(OpCodes.Ret);
        }

        private static void CreateSumMethod(ModuleBuilder module)
        {
            var methodBuilder = module.DefineGlobalMethod(
                "CalculateSum",
                MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.Final,
                typeof(long),
                new Type[] { typeof(int), typeof(int) });

            var ilGenerator = methodBuilder.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Add);
            ilGenerator.Emit(OpCodes.Conv_I8);
            ilGenerator.Emit(OpCodes.Ret);
        }

        private static void ReadAndGreet(ModuleBuilder module)
        {
            var methodBuilder = module.DefineGlobalMethod(
                "ReadAndGreet",
                MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Static,
                typeof(void),
                new Type[] { });

            var ilGenerator = methodBuilder.GetILGenerator();

            LocalBuilder localVariableBuilder = ilGenerator.DeclareLocal(typeof(string));

            var readLineMethod = typeof(Console).GetMethod(
                "ReadLine",
                BindingFlags.Public | BindingFlags.Static);

            var writeMethod = typeof(Console).GetMethod(
                "Write",
                BindingFlags.Public | BindingFlags.Static,
                Type.DefaultBinder,
                new[] { typeof(string) },
                null);

            var writeLineMethod = typeof(Console).GetMethod(
                "WriteLine",
                BindingFlags.Public | BindingFlags.Static,
                Type.DefaultBinder,
                new[] { typeof(string) },
                null);

            ilGenerator.Emit(OpCodes.Ldstr, "Please enter your name:");
            ilGenerator.EmitCall(OpCodes.Call, writeMethod, new[] { typeof(string) });
            ilGenerator.Emit(OpCodes.Call, readLineMethod);
            ilGenerator.Emit(OpCodes.Stloc_0);
            ilGenerator.Emit(OpCodes.Ldstr, "Hello there, nice to meet you ");
            ilGenerator.EmitCall(OpCodes.Call, writeMethod, new[] { typeof(string) });
            ilGenerator.Emit(OpCodes.Ldloc_0);
            ilGenerator.EmitCall(OpCodes.Call, writeLineMethod, new[] { typeof(string) });
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
