using System;
class Factors
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number to find its factors");
        int number = Convert.ToInt32(Console.ReadLine());
        //call methods
        int[] factors = Factor(number);
        int sum = Sum(factors);
        int product = Product(factors);

        //printing results
        Console.WriteLine("The factors are");
        for (int i = 0; i < factors.Length; i++)
        {
            Console.WriteLine(factors[i]);
        }
        Console.WriteLine("The sum of factors is " + sum);
        Console.WriteLine("The product of factors is " + product);
        Console.WriteLine("The sum of squares of factors is " + SumOfSquares(factors));




    }

    //method to calculate factors
    public static  int[] Factor(int num)
    {
         int[] factors = new int[num];
        int count = 0;

        //factor calculation
        for (int i = 1; i <= num; i++)
        {
            if (num % i == 0)
            {
                factors[count] = i;
                count++;
            }
        }
        int[] fact = new int[count];
        for (int i = 0; i < count; i++)
        {
            fact[i] = factors[i];
        }

        return fact;
    }

    //method to calculate sum of factors
    public static int Sum(int[] factors)
    {
        int sum = 0;
        for (int i = 0; i < factors.Length; i++)
        {
            sum += factors[i];
        }
        return sum;
    }

    //method to calculate the sum of squares of factors
    public static int SumOfSquares(int[] factors)
    {
        int sumOfSquares = 0;
        for (int i = 0; i < factors.Length; i++)
        {
            sumOfSquares += factors[i] * factors[i];
        }
        return sumOfSquares;
    }


    //method to calculate product of factors
    public static int Product(int[] factors)
    {
        int product = 1;
        for (int i = 0; i < factors.Length; i++)
        {
            product *= factors[i];
        }
        return product;
    }
}
 
