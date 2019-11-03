using OptionalParameters.Library;
using System;

namespace OptionalParameters.Client
{
    public class Program
    {
        public static void Main()
        {
            // Change the optional parameter amount in the library project with another value an rebuild only the library project.
            // Run the client project in Power Shell and you will see that the anotherBankAccount has amount different than the newly set amount in the library. It will hold the previous amount.

            var bankAccount = new BankAccount("Mincho Minchev", 250);
            bankAccount.PrintInfo();

            Console.WriteLine();

            var anotherBankAccount = new BankAccount("Gergan Gerganov");
            anotherBankAccount.PrintInfo();
        }
    }
}
