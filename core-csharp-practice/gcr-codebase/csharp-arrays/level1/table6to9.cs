using System;
class Table6to9
{
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter a number");
        int number = Convert.ToInt32(Console.ReadLine());

        //intialize array
        int[] result = new int[4];

        for(int i = 6;i<= 9; i++)
        {
            result[i - 6] = i * number;
        }

        //print table
        for(int i = 6; i <= 9; i++)
        {
            Console.WriteLine(number + " * " + i + " = " + result[i - 6]);
        }

    }
}