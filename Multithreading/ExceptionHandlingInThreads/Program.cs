using System;
using System.Threading;

namespace ExceptionHandlingInThreads
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                var thread = new Thread(MethodWithException);
                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("I have caught the exception!");
            }
        }

        public static void MethodWithException()
        {
            throw new ArgumentNullException();
        }
    }
}
