using System;

class BankAccount
{
    //Private fields (Encapsulation)
    private long balance = 50540; //setting the intial amount
    protected string accountNumber = "RBI0001"; //acount number
    private string pass = "1234";


    //method for deposite the amount to the balance
    public void Deposit()
    {
        Console.WriteLine("Enter Password: ");
        string p = Console.ReadLine();
        if(p == pass) //Only proceed if password is correct
        {
            Console.WriteLine("Enter the amount you want to deposite ");
            long amount = Convert.ToInt64(Console.ReadLine()); //user input for enter amount

            if (amount <= 0) //check if amount is less than zero
            {
                Console.WriteLine("Enter the valid amount");
            }
            else
            {
                Console.WriteLine(amount + "is successfully deposite in your account");
                balance += amount;

            }
        }
        else
        {
            Console.WriteLine("Wrong password");
        }
    }

    //mehtod to withdraw the amount
    public void  Withdraw()
    {
        Console.WriteLine("Enter Password: ");
        string p = Console.ReadLine();
        if(p == pass) //Only proceed if password is correct
        {
            Console.WriteLine("Enter the amount you want to withdraw ");
            long amount = Convert.ToInt64(Console.ReadLine()); //user input for amount to withdraw

            if (balance < amount) //check the  balance is less than amount or not
            {
                Console.WriteLine("Low balance");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Withdraw successfull");
            }
        }
        else
        {
            Console.WriteLine("Wrong Password");
        }
    }
    
    //method to check balance
    public void CheckBalance() 
    {
        Console.WriteLine("Enter Password: ");
        string p = Console.ReadLine();
        if(p == pass)//Only proceed if password is correct
        {
            Console.WriteLine("Balance = " + balance); //show balance
        }
        else
        {
            Console.WriteLine("Wrong password");
        }

    }

    //method for display
    protected void Display()
    {
        Console.WriteLine("-----------------------Welocome to XYZ Bank---------------------------");
        while (true) //loop run until user press for exit
        {
            Console.WriteLine("press 1 to check balance:");
            Console.WriteLine("press 2 to deposite amount :");
            Console.WriteLine("press 3 to withdraw money :");
            Console.WriteLine("press 4 to Exit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    CheckBalance();  // method for check balance
                    break;

                case 2:
                    Deposit(); //method for deposite amount
                    break;
                
                case 3:
                    Withdraw(); //mehtod for withdraw the amount
                    break;

                case 4:
                    Environment.Exit(0); //terminatte the code successfully
                    break;
                default:
                    Console.WriteLine("Invalid choice"); //promt for invalid choice
                    break;
            }


        }
    }
}
class App : BankAccount //app class inherit the bankaccount class
{
    public static void Main(String[] args)
    {
        App account = new App(); // calling method

        Console.WriteLine("Please enter your account number ");
        string ACnumber = Console.ReadLine(); // user entered account number
        if (account.accountNumber == ACnumber) //check if account number is correct or not
        {
            account.Display(); // call display method in bankaccount class
        }
        else
        {
            Console.WriteLine("Invalid account number");
        }
    }
}

