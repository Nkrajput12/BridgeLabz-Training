using System;
class SumNatural
{
    //method to calculate sum of first n natural numbers
    public static int Sum(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }
        return sum;
    }
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter a number");
        int n = Convert.ToInt32(Console.ReadLine());
        //call method
        int sum = Sum(n);
        Console.WriteLine("The sum of natural numbers is " + sum);
    }
}