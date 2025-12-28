using System;
class PrimeNum
{
    //method for checking prime number
    public static bool Isprime(int num)
    {
       if(num == 0) return false;
       for(int i = 2;i <= num/2; i++)
        {
            if(num%i == 0)
            {
                return false;
            }
        }
       return true;
    }

    //main method
    public static void Main(string[] args)
    {
        //taking input from user
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (Isprime(number))
        {
            Console.WriteLine("Prime Number ");
        }
        else
        {
            Console.WriteLine("Not a Prime Number");
        }
    }
}
