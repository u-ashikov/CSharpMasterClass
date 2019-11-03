namespace CovarianceAndContravariance
{
    public interface ICovariantGeneric<out T>
        where T : new()
    {
        T Method();
    }

    public class CovariantGeneric<T> : ICovariantGeneric<T>
        where T : new()
    {
        public T Method()
        {
            return new T();
        }
    }
}
