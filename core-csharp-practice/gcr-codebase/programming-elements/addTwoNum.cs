using System;

public class AddTwoNum 
{
    public static void Main(string[] args) 
    {
        Console.WriteLine("Enter first number:");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        int b = Convert.ToInt32(Console.ReadLine());

        int c = a + b;

        Console.WriteLine("The sum is: " + c);
    }
}