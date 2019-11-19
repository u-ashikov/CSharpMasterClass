namespace DynamicExample
{
    public static class ExposedObjectExtensions
    {
        public static ExposedObject Expose(this object obj) =>
            new ExposedObject(obj);
    }
}
