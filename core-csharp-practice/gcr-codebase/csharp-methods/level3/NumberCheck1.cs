using System;

class NumberChecker1
{
    //methods to find the count of digits in the number
    public static int CountDigits(int number)
    {
        // Convert the number to string and get its length
        return number.ToString().Length;
    }

    //method to store the digit in an array
    public static int[] StoreDigitsInArray(int number)
    {
        int digitCount = CountDigits(number);
        int[] digitsArray = new int[digitCount];
        for (int i = digitCount - 1; i >= 0; i--)
        {
            digitsArray[i] = number % 10;
            number /= 10;
        }
        return digitsArray;
    }

    //check the number is a duck number
    public static bool IsDuckNumber(int number)
    {
        int[] digits = StoreDigitsInArray(number);
        for (int i = 1; i < digits.Length; i++)
        {
            if (digits[i] == 0)
            {
                return true;
            }
        }
        return false;
    }

    //method to check the number is a armstrong number
    public static bool IsArmstrongNumber(int number)
    {
        int[] digits = StoreDigitsInArray(number);
        int digitCount = digits.Length;
        int sum = 0;
        foreach (int digit in digits)
        {
            sum += (int)Math.Pow(digit, digitCount);
        }
        return sum == number;
    }

    //method to find the largest and the second largest element in the array
    public static (int largest, int secondLargest) FindLargestAndSecondLargest(int[] numbers)
    {
        int largest = int.MinValue;
        int secondLargest = int.MinValue;
        foreach (int number in numbers)
        {
            if (number > largest)
            {
                secondLargest = largest;
                largest = number;
            }
            else if (number > secondLargest && number != largest)
            {
                secondLargest = number;
            }
        }
        return (largest, secondLargest);
    }

    public static void Main(string[] args)
    {
        //taking input from the user
        Console.WriteLine("enter the number:");
        int number = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine($"Is Duck Number: {IsDuckNumber(number)}");
        Console.WriteLine($"Is Armstrong Number: {IsArmstrongNumber(number)}");
        int[] numbersArray = { 34, 67, 23, 89, 67, 90, 12 };
        var (largest, secondLargest) = FindLargestAndSecondLargest(numbersArray);
        Console.WriteLine($"Largest Number: {largest}");
        Console.WriteLine($"Second Largest Number: {secondLargest}");
    }

}