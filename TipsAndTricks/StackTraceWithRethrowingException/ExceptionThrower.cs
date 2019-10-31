using System;

namespace StackTraceWithRethrowingException
{
    public class ExceptionThrower
    {
        public static void WithStackTrace()
        {
            try
            {
                FirstMethod();
            }
            catch (Exception)
            {
                Console.WriteLine("============ With Stack Trace -> throw");
                throw;
            }
        }

        public static void WithoutStackTrace()
        {
            try
            {
                FirstMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine("============ Without Stack Trace -> throw ex");
                throw ex;
            }
        }

        public static void WithNewException()
        {
            try
            {
                FirstMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine("============ With New Exception -> throw new Exception");
                throw new ArgumentNullException();
            }
        }

        private static void FirstMethod()
        {
            SecondMethod();
        }

        private static void SecondMethod()
        {
            ThirdMethod();
        }

        private static void ThirdMethod()
        {
            throw new ArgumentNullException();
        }
    }
}
