using System;

class BankAccount
{
    public string accountNumber;     //anyone can access it
    protected string accountHolder;  // only this class and derived class
    private double balance;          // only this class can access it

    public BankAccount(string accNum, string holder, double initialBalance)
    {
        this.accountNumber = accNum;
        this.accountHolder = holder;
        this.balance = initialBalance;
    }

    // Public methods to interact with private balance safely
    public void Deposit(double amount)
    {
        if (amount > 0) balance += amount;
    }

    public double CheckBalance() => balance;
}

class SavingsAccount : BankAccount
{
    public SavingsAccount(string n, string h, double b) : base(n, h, b) { }

    public void ShowAccountInfo()
    {
        // We can access accountHolder because it is protected
        Console.WriteLine($"Account: {accountNumber} | Holder: {accountHolder}");
    }
}

class Application
{
    public static void Main()
    {
        SavingsAccount sa = new SavingsAccount("SAV001", "Rahul", 5000);
        sa.ShowAccountInfo();
        sa.Deposit(1500);
        Console.WriteLine("Current Balance: " + sa.CheckBalance());
    }
}