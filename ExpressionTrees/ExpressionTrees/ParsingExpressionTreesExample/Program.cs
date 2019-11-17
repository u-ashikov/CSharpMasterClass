using Common;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ParsingExpressionTreesExample
{
    public class Program
    {
        public static void Main()
        {
            // 1. Constant Example parameters => Expression Body
            Expression<Func<int>> constantExpression = () => 42;

            // 2. Unary Example (Hidden cast)
            Expression<Func<object>> unaryExpression = () => 42;

            // 3. Method Call Example + Extracting parameters
            Expression<Func<Cat, string>> methodCallExpression = (cat) => cat.SayMeow(42);

            // 4. Variables Example
            var someInteger = 42;
            Expression<Func<Cat, string>> variableExpression = (cat) => cat.SayMeow(someInteger);

            // 5. Property Getter Example
            Expression<Func<Cat, string>> propertyExpression = (cat) => cat.Name;
            Expression<Func<Cat, string>> nestedPropertyExpression = (cat) => cat.Owner.FullName;

            // 6. Operator Expression Example
            Expression<Func<int, int, int>> operatorExpression = (x, y) => x + y;

            // 7. Default constructor example
            Expression<Func<Cat>> defaultConstructorExpression = () => new Cat();

            // 8. Constructor with arguments example
            Expression<Func<string, int, Cat>> constructorWithArgumentsExpression = (name, age) => new Cat(name, age);

            // 9. Constructor with member initialization example
            Expression<Func<string, int, string, Cat>> withMemberInitializationExpression = (name, age, owner) => new Cat
            {
                Name = name,
                Age = age,
                Owner = new Owner()
                {
                    FullName = owner
                }
            };

            //ParseExpression(constantExpression, string.Empty);
            //ParseExpression(unaryExpression, string.Empty);
            //ParseExpression(methodCallExpression, string.Empty);
            //ParseExpression(variableExpression, string.Empty);
            //ParseExpression(propertyExpression, string.Empty);
            //ParseExpression(nestedPropertyExpression, string.Empty);
            //ParseExpression(operatorExpression, string.Empty);
            //ParseExpression(defaultConstructorExpression, string.Empty);
            //ParseExpression(constructorWithArgumentsExpression, string.Empty);
            ParseExpression(withMemberInitializationExpression, string.Empty);
        }

        // 1. Check expression type -> Node Type
        // 2. Cast the expression to the found expression type (NodeType)
        // 3. Pass another expression for parsing.
        private static void ParseExpression(Expression expression, string level)
        {
            level += "-";

            if (expression.NodeType == ExpressionType.Lambda)
            {
                Console.WriteLine($"{level}Parsing Lambda Expression...");
                var lambdaExpression = (LambdaExpression)expression;

                var parameters = lambdaExpression.Parameters;

                Console.WriteLine($"{level}Parsing Lambda Expression Parameters...");
                foreach (var param in parameters)
                {
                    ParseExpression(param, level);
                }

                Console.WriteLine($"{level}Parsing Lambda Expression Body...");
                ParseExpression(lambdaExpression.Body, level);
            }
            else if (expression.NodeType == ExpressionType.Constant)
            {
                Console.WriteLine($"{level}Parsing Constant Expression...");
                var constantExpression = (ConstantExpression)expression;
                var value = constantExpression.Value;

                Console.WriteLine($"{level}Constant Expression Value: {value}");
            }
            else if (expression.NodeType == ExpressionType.Convert)
            {
                Console.WriteLine($"{level}Parsing Convert Expression...");
                var unaryExpression = (UnaryExpression)expression;
                var operand = unaryExpression.Operand;

                Console.WriteLine($"{level}Unary Expression Operand: {operand}");
            }
            else if (expression.NodeType == ExpressionType.Call)
            {
                Console.WriteLine($"{level}Parsing Call Expression...");
                var callExpression = (MethodCallExpression)expression;

                var calledMethod = callExpression.Method.Name;
                Console.WriteLine($"{level}Called {calledMethod}...");

                var objectInstance = callExpression.Object;

                ParseExpression(objectInstance, level);

                var arguments = callExpression.Arguments;

                foreach (var arg in arguments)
                {
                    ParseExpression(arg, level);
                }
            }
            else if (expression.NodeType == ExpressionType.Parameter)
            {
                Console.WriteLine($"{level}Parsing Parameter Expression...");
                var parameterExpression = (ParameterExpression)expression;

                Console.WriteLine($"{level} Parameter name: {parameterExpression.Name}");
                Console.WriteLine($"{level} Parameter type: {parameterExpression.Type}");
            }
            else if (expression.NodeType == ExpressionType.MemberAccess)
            {
                Console.WriteLine($"{level}Parsing Member Access Expression...");
                var memberExpression = (MemberExpression)expression;
                var member = memberExpression.Member;

                if (member is FieldInfo field)
                {
                    var instance = (ConstantExpression)memberExpression.Expression;
                    var fieldValue = field.GetValue(instance.Value);

                    Console.WriteLine($"{level}Field Name: {member.Name}, Value: {fieldValue}");
                }

                if (member is PropertyInfo property)
                {
                    Console.WriteLine($"{level}Property Name: {property.Name}, Type: {property.PropertyType.Name}");
                }

                ParseExpression(memberExpression.Expression, level);
            }
            else if (expression.NodeType == ExpressionType.Add)
            {
                Console.WriteLine($"{level}Parsing Simple Binary Expression...");
                var binaryExpression = (BinaryExpression)expression;

                ParseExpression(binaryExpression.Left, level);
                ParseExpression(binaryExpression.Right, level);
            }
            else if (expression.NodeType == ExpressionType.New)
            {
                Console.WriteLine($"{level}Parsing New Expression...");
                var newExpression = (NewExpression)expression;
                var constructor = newExpression.Constructor;

                Console.WriteLine($"{level}Constructor name: {constructor.Name}, Type: {constructor.DeclaringType.Name}");

                var constructorArguments = newExpression.Arguments;

                Console.WriteLine($"{level}Parsing constructor arguments...");

                foreach (var arg in constructorArguments)
                {
                    ParseExpression(arg, level);
                }
            }
            else if (expression.NodeType == ExpressionType.MemberInit)
            {
                Console.WriteLine($"{level}Parsing Member Init Expression...");
                var memberInitExpression = (MemberInitExpression)expression;

                ParseExpression(memberInitExpression.NewExpression, level);

                var bindings = memberInitExpression.Bindings;

                Console.WriteLine($"{level}Parsing bindings...");

                foreach (var binding in bindings)
                {
                    Console.WriteLine($"Binding Type: {binding.BindingType}, Binding Name: {binding.Member.Name}");
                    var memberAssignment = (MemberAssignment)binding;

                    ParseExpression(memberAssignment.Expression, level);
                }
            }
        }
    }
}
