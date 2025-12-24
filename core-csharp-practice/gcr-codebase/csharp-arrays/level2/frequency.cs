

using System;
class Frequency
{
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter a number");
        int number = Convert.ToInt32(Console.ReadLine());
        //finding the count of digits
        int temp = number;
        int count = 0;
        while (temp > 0)
        {
            count++;
            temp /= 10;
        }
        //creating an array to store digits
        int[] digits = new int[count];
        temp = number;
        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = temp % 10;
            temp /= 10;
        }
        
        int[] frequency = new int[10];
        //finding the frequency of each digit
        for (int i = 0; i < digits.Length; i++)
        {
            frequency[digits[i]]++;
        }
        //displaying the frequency of each digit
        Console.WriteLine("Digit Frequency");
        for (int i = 0; i < frequency.Length; i++)
        {
            if (frequency[i] > 0)
            {
                Console.WriteLine("Digit " + i + ": " + frequency[i]);
            }
        }
    }
}