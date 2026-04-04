using System;
class NumberCheck4
{
    //method to check if a number is prime
    public static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    //method to check if a number is neon 
    public static bool IsNeon(int number)
    {
        int square = number * number;
        int sumOfDigits = 0;
        while (square > 0)
        {
            sumOfDigits += square % 10;
            square /= 10;
        }
        return sumOfDigits == number;
    }

    //method to check if a number is spy
    public static bool IsSpy(int number)
    {
        int sum = 0;
        int product = 1;
        while (number > 0)
        {
            int digit = number % 10;
            sum += digit;
            product *= digit;
            number /= 10;
        }
        return sum == product;
    }

    //method to check if a number is automorphic
    public static bool IsAutomorphic(int number)
    {

        int square = number * number;
        string numberStr = number.ToString();
        string squareStr = square.ToString();
        return squareStr.EndsWith(numberStr);
    }

    //method to check if a number is buzz
    public static bool IsBuzz(int number)
    {
        return number % 7 == 0 || number.ToString().EndsWith("7");
    }


    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine($"{number} is prime: {IsPrime(number)}");
        Console.WriteLine($"{number} is neon: {IsNeon(number)}");
        Console.WriteLine($"{number} is spy: {IsSpy(number)}");
        Console.WriteLine($"{number} is automorphic: {IsAutomorphic(number)}");
        Console.WriteLine($"{number} is buzz: {IsBuzz(number)}");
    }
}

