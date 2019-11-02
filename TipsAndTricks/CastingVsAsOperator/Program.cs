using System;

namespace CastingVsAsOperator
{
    public class Program
    {
        public static void Main()
        {
            object number = 10;
            //string numberAsString = (string)number;

            // InvalidCastException will be thrown.
            //Console.WriteLine(numberAsString);

            // The number will be null, ant won't throw exception.
            string numberAsString = number as string;
            Console.WriteLine(numberAsString);
        }
    }
}
