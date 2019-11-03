using CovarianceAndContravariance.ClassHierarchy;

namespace CovarianceAndContravariance
{
    public class Program
    {
        public static void Main()
        {
            WithInvariantGeneric();
            WithContravariantGeneric();
            WithCovariantGeneric();
        }

        private static void WithCovariantGeneric()
        {
            ICovariantGeneric<MIddleClass> covariantGeneric = new CovariantGeneric<LastClass>();
            var result = covariantGeneric.Method();
        }

        private static void WithContravariantGeneric()
        {
            IContravariantGeneric<LastClass> contravariantGeneric = new ContravariantGeneric<MIddleClass>();
            contravariantGeneric.Method(new LastClass());
        }

        private static void WithInvariantGeneric()
        {
            IInvariantGeneric<MIddleClass> invariantGeneric = new InvariantGeneric<MIddleClass>();
            invariantGeneric.Method(new MIddleClass());
        }
    }
}
