using System;
class SumofNatural
{
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter a number");
        int number = Convert.ToInt32(Console.ReadLine());

        //check for natural number
        if (number <= 0)
        {
            Console.Error.WriteLine("Please enter a natural number");
            Environment.Exit(0);
        }
        else
        {
            //calculating sum using formula and recursion
            int sumformula = (number * (number + 1)) / 2;
            int sumrecursion = Sum(number);
            //comparing both sums
            if (sumformula == sumrecursion)
            {
                Console.WriteLine("the sum is "+ sumformula+" which is equal by both methods");
            }
            else
            {
                Console.WriteLine("both sum are not equal");
            }

        }

    }
    //method to calculate sum recursively
    public static int Sum(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        else
        {
            return n + Sum(n - 1);
        }
    }
}

