using System;
using System.Linq.Expressions;

namespace InstancesCreation
{
    public class InstanceCreator<T>
        where T : class
    {
        public static Func<T> Instance() => Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
    }
}
