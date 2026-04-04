using System;

class MultiplicationTable
{
    public static void Main(string[]args)
    {   
        //taking input from user
        System.Console.WriteLine("Enter a number to print its table");
        int number = Convert.ToInt32(Console.ReadLine());

        //store the values of multiplication in array
        int[] value = new int[10];
        for(int i = 0; i < 10; i++)
        {
            value[i] = (i + 1) * number;
        }

        //print table
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine(number + " * " + (i + 1) + " = " + value[i]);
        }
    }
}

