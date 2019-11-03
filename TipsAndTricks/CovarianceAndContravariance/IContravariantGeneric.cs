using System;

namespace CovarianceAndContravariance
{
    public interface IContravariantGeneric<in T>
    {
        void Method(T parameter);
    }

    public class ContravariantGeneric<T> : IContravariantGeneric<T>
    {
        public void Method(T parameter)
        {
            Console.WriteLine(parameter.GetType());
        }
    }
}
