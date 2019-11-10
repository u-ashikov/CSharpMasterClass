using System;

namespace Generics
{
    public class Cat
    {
        public void WhoAmI<T>(T item) => Console.WriteLine(item.GetType());
    }
}
