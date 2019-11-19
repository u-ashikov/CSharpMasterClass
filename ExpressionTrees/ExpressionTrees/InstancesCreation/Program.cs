using Common;

namespace InstancesCreation
{
    public class Program
    {
        public static void Main()
        {
            var cat = InstanceCreator<Cat>.Instance();
        }
    }
}
