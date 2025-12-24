using System;
class Missing
{
    public static void Main(string[] args)
    {
        //take user input
        Console.WriteLine("enter the number of elements");
        int number = Convert.ToInt32(Console.ReadLine());

        //declaring the array
        int[] arr = new int[number];


        //taking input in array
        Console.WriteLine("enter the elements inside array");
        for(int i = 0; i < number; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());

        }

        int missing_num = 0;

        //check for missing number
        for(int i = 0; i < number; i++)
        {
            if (arr[i] != (i + 1))
            {
                missing_num = i+1;
                break;
            }
        }

        Console.WriteLine("the missing number is " + missing_num);
    }
}