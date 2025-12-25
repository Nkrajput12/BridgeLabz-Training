using System;
class NumberCheck5
{
    //method to find factor of a number and return as array
    public static int[] GetFactors(int number)
    {
        int[] factors = new int[number];
        int count = 0;
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                factors[i - 1] = i;
                count++;
            }
        }
        int[] result = new int[count];
        for (int i = 0; i < count; i++)
        {
            result[i] = factors[i];
        }
        return result;

    }

    //method to find gretest factor of a number
    public static int GetGreatestFactor(int number)
    {
        for (int i = number / 2; i >= 1; i--)
        {
            if (number % i == 0)
            {
                return i;
            }
        }
        return 1; 
    }

    //method to find product of factors of a number
    public static int GetProductOfFactors(int number)
    {
        int[] arr = GetFactors(number);
        int product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                product *= arr[i];
            }
        }
        return product;
    }

    //method to find product of cube of factors
    public static int GetProductOfCubeOfFactors(int number)
    {
        int[] arr = GetFactors(number);
        int product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                product *= (int)Math.Pow(arr[i], 3);
            }
        }
        return product;
    }

    //method to check if a number is perfect
    public static bool IsPerfect(int number)
    {
        int sum = 0;
        for (int i = 1; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                sum += i;
            }
        }
        return sum == number;
    }

    //method to check if a number is abundant
    public static bool IsAbundant(int number)
    {
        int sum = 0;
        for (int i = 1; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                sum += i;
            }
        }
        return sum > number;
    }

    //method to check if a number is deficient
    public static bool IsDeficient(int number)
    {
        int sum = 0;
        for (int i = 1; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                sum += i;
            }
        }
        return sum < number;
    }

    //method to check if numbers are strong
    public static bool IsStrong(int number)
    {
        int sum = 0;
        int temp = number;
        while (temp > 0)
        {
            int digit = temp % 10;
            sum += Factorial(digit);
            temp /= 10;
        }
        return sum == number;
    }

    //method to calculate factorial
    public static int Factorial(int n)
    {
        if (n == 0 || n == 1)
        {
            return 1;
        }
        int fact = 1;
        for (int i = 2; i <= n; i++)
        {
            fact *= i;
        }
        return fact;
    }

    public static void Main(string[] args)
    {
        //taking input from user    
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        //printing results
        Console.WriteLine($"Factors of {number}: {string.Join(", ", GetFactors(number))}");
        Console.WriteLine($"Greatest factor of {number}: {GetGreatestFactor(number)}");
        Console.WriteLine($"Product of factors of {number}: {GetProductOfFactors(number)}");
        Console.WriteLine($"Product of cube of factors of {number}: {GetProductOfCubeOfFactors(number)}");
        Console.WriteLine($"{number} is perfect: {IsPerfect(number)}");
        Console.WriteLine($"{number} is abundant: {IsAbundant(number)}");
        Console.WriteLine($"{number} is deficient: {IsDeficient(number)}");
        Console.WriteLine($"{number} is strong: {IsStrong(number)}");
    }



}