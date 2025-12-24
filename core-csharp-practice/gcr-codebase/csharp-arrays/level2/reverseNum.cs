using System;
public class  ReverseNum
{
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter a number");
        long number = Convert.ToInt64(Console.ReadLine());
        //intialize the array
        int[] digit = new int[20];

        //intialize counter 
        int counter = 0;
        long rem = 0;
        int i = 0;

        //revarse the digits and store it in an array
        while (number>0)
        {
            if (i >= 20)
            {
                break;
            }
            rem = number % 10;
            digit[i] = (int)rem;
            counter++;
            i++;

            number /= 10;
        }

        //print the reverse of the number
        for (i = 0; i < counter; i++)
        {
            Console.Write(digit[i]);
        }
        


    }

}