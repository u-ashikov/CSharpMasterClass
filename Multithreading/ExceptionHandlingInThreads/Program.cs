using System;
using System.Threading;

namespace ExceptionHandlingInThreads
{
    public class Program
    {
        public static void Main()
        {
            var thread = new Thread(MethodWithException);
            thread.Start();
        }

        public static void MethodWithException()
        {
            try
            {
                throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                Console.WriteLine("I have caught the exception!");
            }
        }
    }
}
