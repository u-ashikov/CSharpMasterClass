namespace InstancesAndInvocations
{
    public interface ICat
    {
        string Name { get; }

        int Age { get; }

        string Eat(string food);
    }
}
