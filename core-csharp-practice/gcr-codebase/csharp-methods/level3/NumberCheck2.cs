using System;

class NumberChecker
{
    // Method to find the count of digits
    public static int GetDigitCount(int number)
    {
        // Handle 0 separately or use Math.Abs for negative numbers
        return number.ToString().Length;
    }

    //  Method to store the digits of the number in a digits array
    public static int[] StoreDigitsInArray(int number)
    {
        int count = GetDigitCount(number);
        int[] digitsArray = new int[count];
        int temp = Math.Abs(number);

        for (int i = count - 1; i >= 0; i--)
        {
            digitsArray[i] = temp % 10;
            temp /= 10;
        }
        return digitsArray;
    }

    //Method to find the sum of the digits using the digits array
    public static int CalculateSumOfDigits(int[] digits)
    {
        int sum = 0;
        foreach (int digit in digits)
        {
            sum += digit;
        }
        return sum;
    }

    //Method to find the sum of the squares of the digits using the digits array
    public static int CalculateSumOfSquares(int[] digits)
    {
        int sumOfSquares = 0;
        foreach (int digit in digits)
        {
            // Use Math.Pow and cast back to int
            sumOfSquares += (int)Math.Pow(digit, 2);
        }
        return sumOfSquares;
    }

    // d: Method to Check if a number is a Harshad number

    public static bool IsHarshadNumber(int number)
    {
        int[] digits = StoreDigitsInArray(number);
        int sum = CalculateSumOfDigits(digits);

        // A Harshad number must be divisible by its sum (sum cannot be 0)
        return sum != 0 && number % sum == 0;
    }

    // e: Method to find the frequency of each digit using a 2D array
    public static int[,] GetDigitFrequency(int[] digits)
    {
        // Temporary array to count occurrences of digits 0-9
        int[] counts = new int[10];
        int uniqueDigitCount = 0;

        foreach (int digit in digits)
        {
            if (counts[digit] == 0) uniqueDigitCount++;
            counts[digit]++;
        }

        // Create a 2D array: [rows = unique digits, columns = 2 (digit and frequency)]
        int[,] frequencyTable = new int[uniqueDigitCount, 2];
        int currentRow = 0;

        for (int i = 0; i < 10; i++)
        {
            if (counts[i] > 0)
            {
                frequencyTable[currentRow, 0] = i; // First column: The digit
                frequencyTable[currentRow, 1] = counts[i]; // Second column: The frequency
                currentRow++;
            }
        }
        return frequencyTable;
    }

    public static void Main(string[] args)
    {
        // Taking input from the user
        Console.Write("Enter a number");
        int input = Convert.ToInt32(Console.ReadLine());

        // A: Digit Count and Array
        int[] digits = StoreDigitsInArray(input);
        Console.WriteLine($"\nDigit Count: {GetDigitCount(input)}");
        Console.WriteLine($"Digits Array: {string.Join(", ", digits)}");

        // B: Sum of Digits
        int sum = CalculateSumOfDigits(digits);
        Console.WriteLine($"Sum of Digits: {sum}");

        // C: Sum of Squares
        int squaresSum = CalculateSumOfSquares(digits);
        Console.WriteLine($"Sum of Squares: {squaresSum}");

        // D: Harshad Number Check
        bool isHarshad = IsHarshadNumber(input);
        Console.WriteLine($"Is Harshad Number: {isHarshad}");

        // E: Frequency Table
        int[,] freq = GetDigitFrequency(digits);
        Console.WriteLine("\nDigit Frequency Table:");
        Console.WriteLine("Digit\tFrequency");
        for (int i = 0; i < freq.GetLength(0); i++)
        {
            Console.WriteLine($"{freq[i, 0]}\t{freq[i, 1]}");
        }
    }
}