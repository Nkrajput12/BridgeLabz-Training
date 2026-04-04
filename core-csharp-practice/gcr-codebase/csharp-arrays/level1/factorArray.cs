using System;
class FactorArray
{
    public static void Main(string[] args)
    {
        //take input
        Console.WriteLine("Enter a number");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = new int[number];
        int count = 0;  

        //find factors
        for (int i = 1, j = 0; i <= number; i++)
        {
            if (number % i == 0)
            {
                factors[j] = i;
                j++;
                count++;
            }
        }

        //print factors
        Console.WriteLine("Factors of " + number + " are");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(factors[i]);
        }

    }
}
