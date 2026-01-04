using System;
using System.Numerics;
class BankAccount
{
    static string BankName = "Bharat Bank"; //static Bank name shared among all instances inside the class
    static private int totalAcNumber = 0; // total ac number private to secure it
    public string accountHolderName; 
    public readonly string accountNumber; //use readonly to prevent it from changes

    public  void GetTotalAccount() //method to get the total account number
    {
       Console.WriteLine("number of accounts created = "+totalAcNumber);
    }

    public BankAccount(string accountHolderName, string accountNumber) // constructor to assign the value
    {                                                                  // of ac holder name and number 
        this.accountHolderName = accountHolderName;
        this.accountNumber = accountNumber;
        totalAcNumber++; //increment the total ac number
    }

    public void Display() //method to display the details
    {
        Console.WriteLine("Bank name = " + BankName);
        Console.WriteLine("Account Holder name = "+accountHolderName);
        Console.WriteLine("Account Holder number = "+accountNumber);
    }

}
class Application // application class 
{
    public static void Main(string[] args)
    {
        BankAccount acc1 = new BankAccount("Raj", "ACC0001"); // create first object
        BankAccount acc2 = new BankAccount("Mohan", "ACC0002"); //creat second object
        
        if(acc1 is BankAccount && acc2 is BankAccount) //check if the objects are the instance of class or not
        {
            Console.WriteLine("Yes the object is an instance of class");
            acc1.Display(); //call method to display the details
        }

        acc2.GetTotalAccount(); //get the total account number
    }
}
