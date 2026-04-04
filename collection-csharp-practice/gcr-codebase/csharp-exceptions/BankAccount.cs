using System;

namespace BankSystem
{
    // 1. Custom Exception for insufficient funds
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

    public class BankAccount
    {
        public double Balance { get; private set; }

        public BankAccount(double initialBalance)
        {
            Balance = initialBalance;
        }

        // 2. Withdraw method with Exception logic
        public void Withdraw(double amount)
        {
            // Rule: Throw ArgumentException if amount is negative
            if (amount < 0)
            {
                throw new ArgumentException("Invalid amount!");
            }

            // Rule: Throw InsufficientFundsException if amount exceeds balance
            if (amount > Balance)
            {
                throw new InsufficientFundsException("Insufficient balance!");
            }

            // If valid, update balance and print success
            Balance -= amount;
            Console.WriteLine($"Withdrawal successful, new balance: {Balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initializing account with 1000 units
            BankAccount myAccount = new BankAccount(1000);

            Console.WriteLine($"Current Balance: {myAccount.Balance}");
            Console.Write("Enter amount to withdraw: ");

            // 3. Handling exceptions in Main()
            try
            {
                string input = Console.ReadLine();
                double amount = double.Parse(input);

                myAccount.Withdraw(amount);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid numerical amount.");
            }
            catch (ArgumentException ex)
            {
                // Catches the negative amount error
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InsufficientFundsException ex)
            {
                // Catches the balance exceeded error
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch-all for any other errors
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("\nSession ended. Press any key to exit.");
            Console.ReadKey();
        }
    }
}