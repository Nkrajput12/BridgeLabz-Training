using System;
class LargestDigit2
{
    public static void Main(string[] args)
    {   //input number from user
        Console.WriteLine("enter a number");
        long number = Convert.ToInt64(Console.ReadLine());
        //intialize the digit and temp array
        int max_digit = 10;
        int[] digit = new int[max_digit];
        int[] temp = new int[max_digit];
        
        long rem = 0;
        //storing digits in the array
        for (int i = 0; i < max_digit; i++)
        {
            rem = number % 10;
            digit[i] = (int)rem;
            number = number / 10;
        }
        //storing previous digits in temp array if number digits is more than 10
        if (number > 0)
        {
            for(int i = 0; i < max_digit; i++)
            {
                temp[i] = digit[i];
            }
            for (int i = 0; i < max_digit; i++)
            {
                rem = number % 10;
                digit[i] = (int)rem;
                number = number / 10;
            }
        }
        //finding the largest digit from both arrays
        int largest = digit[0]; 
        for(int i = 0; i < max_digit; i++)
        {
            if(digit[i] > largest)
            {
                largest = digit[i];
            }
        }
        for(int i = 0; i < max_digit; i++)
        {
            if(temp[i] > largest)
            {
                largest = temp[i];
            }
        }

        //finding the second largest digit from both arrays
        int second_largest = 0;
        for(int i = 0; i < max_digit; i++)
        {
            if(digit[i] > second_largest && digit[i] < largest)
            {
                second_largest = digit[i];
            }
        }
        for(int i = 0; i < max_digit; i++)
        {
            if(temp[i] > second_largest && temp[i] < largest)
            {
                second_largest = temp[i];
            }
        }

        Console.WriteLine("The largest digit is " + largest);
        Console.WriteLine("The second largest digit is " + second_largest);

    }
}