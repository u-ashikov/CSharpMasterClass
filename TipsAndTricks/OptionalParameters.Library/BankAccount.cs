using System;

namespace OptionalParameters.Library
{
    public class BankAccount
    {
        public BankAccount(string accountHolder, decimal amount = 999)
        {
            this.AccountHolder = accountHolder;
            this.Amount = amount;
        }

        public string AccountHolder { get; }
        public decimal Amount { get; }

        public void PrintInfo()
        {
            Console.WriteLine($"Bank Account Info: Holder: {this.AccountHolder}, Amount: {this.Amount.ToString("0.00")} $");
        }
    }
}
