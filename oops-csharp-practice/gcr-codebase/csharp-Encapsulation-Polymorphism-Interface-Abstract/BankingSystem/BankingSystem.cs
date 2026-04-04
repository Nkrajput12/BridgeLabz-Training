using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.BankingSystem
{
    public interface ILoanable
    {
        void ApplyForLoan(double amount);
        bool CalculateLoanEligibility();
    }

    // --- 2. THE ABSTRACT BASE CLASS ---
    // Provides the foundation. It cannot be instantiated directly.
    public abstract class BankAccount
    {
        // ENCAPSULATION: Private fields protect the data from direct external access
        private string _accountNumber;
        private string _holderName;
        private double _balance;

        // Properties allow controlled reading of data
        public string AccountNumber => _accountNumber;
        public string HolderName => _holderName;
        public double Balance => _balance;

        public BankAccount(string accNo, string name, double initialBalance)
        {
            _accountNumber = accNo;
            _holderName = name;
            _balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine($"[Deposit] {_holderName}: +${amount}. New Balance: ${_balance:F2}");
            }
        }

        public virtual void Withdraw(double amount)
        {
            if (amount > 0 && amount <= _balance)
            {
                _balance -= amount;
                Console.WriteLine($"[Withdraw] {_holderName}: -${amount}. Remaining: ${_balance:F2}");
            }
            else
            {
                Console.WriteLine($"[Error] {_holderName}: Insufficient funds for ${amount} withdrawal.");
            }
        }

        // ABSTRACTION: Every child class must define how interest is calculated
        public abstract void CalculateInterest();
    }

    // --- 3. SUBCLASSES (INHERITANCE) ---

    // Savings Account: Earns interest and is eligible for loans
    public class SavingsAccount : BankAccount, ILoanable
    {
        private const double InterestRate = 0.05; // 5% Interest

        public SavingsAccount(string accNo, string name, double balance)
            : base(accNo, name, balance) { }

        public override void CalculateInterest()
        {
            double interest = Balance * InterestRate;
            Console.WriteLine($"[Interest] Savings ({HolderName}): Earned ${interest:F2} at 5%.");
        }

        public void ApplyForLoan(double amount)
        {
            if (CalculateLoanEligibility())
                Console.WriteLine($"[Loan] APPROVED: ${amount} loan for {HolderName}.");
            else
                Console.WriteLine($"[Loan] DENIED: {HolderName} does not meet the $5,000 minimum balance requirement.");
        }

        public bool CalculateLoanEligibility() => Balance >= 5000;
    }

    // Current Account: Higher flexibility, no interest
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(string accNo, string name, double balance)
            : base(accNo, name, balance) { }

        public override void CalculateInterest()
        {
            Console.WriteLine($"[Interest] Current ({HolderName}): No interest applied to current accounts.");
        }

        // Example of Method Overriding for specific behavior
        public override void Withdraw(double amount)
        {
            Console.WriteLine("[System] Processing withdrawal from Current Account...");
            base.Withdraw(amount);
        }
    }

    // --- 4. MAIN PROGRAM (POLYMORPHISM) ---
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BRIDGE LABZ BANKING SYSTEM ===\n");

            
            // can store objects of any derived type (Savings or Current).
            List<BankAccount> accounts = new List<BankAccount>();

            accounts.Add(new SavingsAccount("1212", "Rammu", 6500.00));
            accounts.Add(new CurrentAccount("1313", "Mohan", 1200.00));
            accounts.Add(new SavingsAccount("1414", "Sonu", 3000.00));

            // Process all accounts dynamically
            foreach (var acc in accounts)
            {
                Console.WriteLine($"--- Processing Account: {acc.AccountNumber} ---");

                // Dynamic Dispatch: Calls the version of CalculateInterest 
                // belonging to the specific object type.
                acc.CalculateInterest();
                acc.Deposit(200);

                // INTERFACE CHECK: See if the account supports loans
                if (acc is ILoanable loanAccount)
                {
                    loanAccount.ApplyForLoan(15000);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
