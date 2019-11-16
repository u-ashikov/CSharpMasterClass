using System;
using System.Linq.Expressions;

namespace ExpressionTreesExamples
{
    public class Program
    {
        public static void Main()
        {
            // 1. Example
            Expression<Func<int>> constant = () => 42;
        }
    }
}
