namespace MethodDeprecation
{
    public class Program
    {
        public static void Main()
        {
            var writer = new TextWriter();

            writer.WriteToFile("text.txt", "Hello world.");
        }
    }
}
