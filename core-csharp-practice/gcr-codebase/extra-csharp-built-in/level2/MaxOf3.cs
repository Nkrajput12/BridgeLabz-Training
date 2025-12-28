using System;
class MaxOf3
{
    //method for calculating the maximum of three number
    public static int FindMax(int a, int b, int c)
    {
        if (a > b && a > c) return a;
        else if (b > a && b > c) return b;
        else return c;
    }

    //main method
    public static void Main(string[] args)
    {
        //taking input from user
        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nEnter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nEnter Third number: ");
        int num3 = Convert.ToInt32(Console.ReadLine());
        //calling method
        int result = FindMax(num1, num2, num3);


        Console.WriteLine("The maximum number is " + result);

    }
}

