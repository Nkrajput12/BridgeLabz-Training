using System;
using System.Timers;
class MathOperations
{
    //method to calculate factorial
    int GetFactorial(int num)
    {
        

        if (num < 0) return -1;
        if (num == 1 || num == 0) return 1;
        else return num * GetFactorial(num - 1);

    }

    //method for checking prime number
    void Isprime()
    {
        Console.Write("Enter Number: ");
        int num = Convert.ToInt32(Console.ReadLine()); //take user input and assign in num
         
        if (num <= 0) Console.WriteLine("Not a prime number "); //if num is less than 0 it is not prime
        else if (num > 0) //check for prime
        {
            int flag = 0; //intillize flag to check divisibility
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    flag++; //ig number is divisible increment flag
                }
            }
            if (flag > 0) Console.WriteLine("Not a prime number");
            else Console.WriteLine("prime number ");

        }
    }

    //method to calcualte GCD
    void GetGcd()
    {
        //taking user input for first and second
        Console.Write("Enter the first number: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int b = Convert.ToInt32(Console.ReadLine());
        //loop for finding the gcd
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        Console.WriteLine("The Gcd is = " + a); //print the result
    }

    //method to generate and display the fibonacci series
    void GetFibonacci()
    {
        Console.Write("Enter Number: ");
        int num = Convert.ToInt32(Console.ReadLine()); //take user input of number


        if(num < 0) Console.WriteLine("Invalid input"); //if num is less than 0 invalid input
        if (num == 0) Console.WriteLine("The nth fibonacci number is 0"); // if num is 0 ans is 0
        else
        {
            if (num == 1) Console.WriteLine("The nth fibonacci number is 1");//check for 1
            else
            {
                int a = 0, b = 1; //assign 0 to a and 1 to b 
                for (int i = 2; i <= num; i++) //loop for finding the nth number
                {
                    int c = a + b;
                    a = b;
                    b = c;
                }
                Console.WriteLine("The nth fibonacci number is " + b); //display the result
            }
        }
        

    }

    //main method
    public static void Main(string[] args)
    {
        MathOperations math = new MathOperations(); //declare object
        
        while (true)
        {
            Console.WriteLine("Press 1 for factorial: ");//prompt user for choices
            Console.WriteLine("Press 2 for prime    : ");
            Console.WriteLine("Press 3 for GCD of 2 : ");
            Console.WriteLine("Press 4 for fibonacci: ");
            Console.WriteLine("Press 5 for Exit     : ");
            int choice = Convert.ToInt32 (Console.ReadLine()); // input user choice

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Number: "); //taking user input
                    int num = Convert.ToInt32(Console.ReadLine());
                    int factorial = math.GetFactorial(num); // call method to find factorial
                    if (factorial == -1) Console.WriteLine("Invalid Input"); // if return is -1 invalid input
                    else Console.WriteLine("factorial = "+factorial); //display the factorial
                    break;

                case 2:

                    math.Isprime(); //method to find prime.
                    break;

                case 3:
                    math.GetGcd(); //mehtod to get gcd.
                    break;

                case 4:
                    math.GetFibonacci(); //method to get the fibonacci number.
                    
                break;

                case 5:
                    Environment.Exit(0); //method to terminate the code successfully

                    break;

                default:
                    Console.WriteLine("Invalid input"); //if user select wrong input
                    break;


            }

        }
        
    }



}

