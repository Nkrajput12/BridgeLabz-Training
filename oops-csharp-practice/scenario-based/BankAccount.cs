using System;

class BankAccount
{
    public long balance = 50540; //setting the intial amount
    public string accountNumber = "RBI0001"; //acount number
    public string pass = "1234";


    //method for deposite the amount to the balance
    public void Deposite()
    {
        Console.WriteLine("Enter Password: ");
        string p = Console.ReadLine();
        if(p == pass)
        {
            Console.WriteLine("Enter the amount you want to deposite ");
            long amount = Convert.ToInt64(Console.ReadLine());

            if (amount <= 0)
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
        if(p == pass)
        {
            Console.WriteLine("Enter the amount you want to withdraw ");
            long amount = Convert.ToInt64(Console.ReadLine());

            if (balance < amount)
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
        if(p == pass)
        {
            Console.WriteLine("Balance = " + balance);
        }
        else
        {
            Console.WriteLine("Wrong password");
        }

    }

    //method for display
    public void Display()
    {
        Console.WriteLine("-----------------------Welocome to XYZ Bank---------------------------");
        while (true)
        {
            Console.WriteLine("press 1 to check balance:");
            Console.WriteLine("press 2 to deposite amount :");
            Console.WriteLine("press 3 to withdraw money :");
            Console.WriteLine("press 4 to Exit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    CheckBalance(); 
                    break;

                case 2:
                    Deposite();
                    break;
                
                case 3:
                    Withdraw();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }


        }
    }
}
class App
{
    public static void Main(String[] args)
    {
        BankAccount account = new BankAccount();

        Console.WriteLine("Please enter your account number ");
        string ACnumber = Console.ReadLine();
        if (account.accountNumber == ACnumber)
        {
            account.Display();
        }
        else
        {
            Console.WriteLine("Invalid account number");
        }
    }
}

