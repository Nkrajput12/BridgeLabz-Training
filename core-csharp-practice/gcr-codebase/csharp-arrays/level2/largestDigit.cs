using System;
using System.Runtime.ExceptionServices;

class LargestDigit
{
    public static void Main(string[] args)
    {   
        Console.WriteLine("Enter a number");
        //taking number input
        long number = Convert.ToInt64(Console.ReadLine());

        int max_digit = 10;
        //intialize the array
        int[] digit = new int[max_digit];

        long rem = 0;
        for(int i = 0; i < max_digit; i++)
        {
            rem = number % 10;
            digit[i] = (int)rem;
            number = number / 10;
        }

        //finding the largest digit
        int largest = digit[0];
        for(int i = 0; i < max_digit; i++)
        {
            if(digit[i] > largest)
            {
                largest = digit[i];
            }
        }

        //finding the second largest digit
        int second_largest = 0;
        for(int i = 0; i < max_digit; i++)
        {
            if(digit[i] > second_largest && digit[i] < largest)
            {
                second_largest = digit[i];
            }
        }

        Console.WriteLine("The largest digit is " + largest);
        Console.WriteLine("The second largest digit is " + second_largest);
    }
}
