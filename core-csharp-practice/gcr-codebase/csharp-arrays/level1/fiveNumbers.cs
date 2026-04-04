using System;
class FiveNumbers
{
    public static void Main(string[] args)
    {
        int[] numbers = new int[5];
        Console.WriteLine("Enter five numbers:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Number "+i + 1+" ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < 5; i++)
        {
            if (numbers[i] > 0)
            {
                if(numbers[i] % 2 == 0)
                {
                    Console.WriteLine(numbers[i] + " is even number");
                }
                else
                {
                    Console.WriteLine(numbers[i] + " is odd number");
                }
            }
            else if (numbers[i] < 0)
            {
                Console.WriteLine(numbers[i] + " is Negative number");
            }
            else
            {
                Console.WriteLine(numbers[i] + " is Zero");
            }
        }
        if (numbers[0] > numbers[4]) 
        {
            Console.WriteLine("first number is greater than last number");
        }
        else if (numbers[0] < numbers[4]) 
        {
            Console.WriteLine("last number is greater than first number");
        }
        else
        {
            Console.WriteLine("first number and last number are equal");
        }

    }
}

