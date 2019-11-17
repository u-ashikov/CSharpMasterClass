using Common;
using System;
using System.Linq.Expressions;

namespace CreatingExpressionTreesExample
{
    public class Program
    {
        public static void Main()
        {
            // 1. Generate () => 42;
            CreateConstantExpression();

            // Creating instance with expression is faster than Activator.CreateInstance();
            // 2. Generate () => new Cat();
            CreateNewExpression();

            // 3. Generate (cat) => cat.SayMeow(42);
            CreateMethodCallExpression();

            // 4. Generate (cat, number) => cat.SayMeow(number);
            CreateMethodCallWithParameter();

            // 5. Generate (name, age) => new Cat(name, age)
            CreateNewExpressionWithParameters();
        }

        private static void CreateConstantExpression()
        {
            var constantExpression = Expression.Constant(42);
            var lambdaExpression = Expression.Lambda<Func<int>>(constantExpression);

            var func = lambdaExpression.Compile();

            Console.WriteLine(func());
        }

        private static void CreateNewExpression()
        {
            var newExpression = Expression.New(typeof(Cat));
            var lambdaExpression = Expression.Lambda<Func<Cat>>(newExpression);

            var func = lambdaExpression.Compile();

            var cat = func();
        }

        private static void CreateMethodCallExpression()
        {
            var expressionParameter = Expression.Parameter(typeof(Cat), nameof(Cat).ToLower());
            var constantExpression = Expression.Constant(42);

            var expressionBody = Expression.Call(expressionParameter, typeof(Cat).GetMethod("SayMeow"), constantExpression);

            var lambdaExpression = Expression.Lambda<Func<Cat, string>>(expressionBody, expressionParameter);

            var func = lambdaExpression.Compile();

            Console.WriteLine(func(new Cat()));
        }

        private static void CreateMethodCallWithParameter()
        {
            var catParameter = Expression.Parameter(typeof(Cat), nameof(Cat).ToLower());
            var numParameter = Expression.Parameter(typeof(int), "number");

            var methodCallExpression = Expression.Call(catParameter, typeof(Cat).GetMethod("SayMeow"), numParameter);
            var lambdaExpression = Expression.Lambda<Func<Cat, int, string>>(methodCallExpression, catParameter, numParameter);

            var func = lambdaExpression.Compile();

            Console.WriteLine(func(new Cat(), 100));
        }

        private static void CreateNewExpressionWithParameters()
        {
            var nameParameter = Expression.Parameter(typeof(string), "name");
            var ageParameter = Expression.Parameter(typeof(int), "age");

            var constructor = typeof(Cat).GetConstructor(new Type[] { typeof(string), typeof(int) });
            var newExpression = Expression.New(constructor, nameParameter, ageParameter);
            var lambdaExpression = Expression.Lambda<Func<string, int, Cat>>(newExpression, nameParameter, ageParameter);

            var func = lambdaExpression.Compile();

            var cat = func("Pesho", 10);

            Console.WriteLine($"Cat name: {cat.Name}");
            Console.WriteLine($"Cat age: {cat.Age}");
        }
    }
}
