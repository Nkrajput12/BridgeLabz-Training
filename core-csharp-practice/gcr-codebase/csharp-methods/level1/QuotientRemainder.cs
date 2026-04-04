using System;
class QuotientRemainder
{
    //method to calculate quotient and remainder
    public static int[] Calculate(int dividend, int divisor)
    {
        int quotient = dividend / divisor;
        int remainder = dividend % divisor;
        return new int[] { quotient, remainder };
    }
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter dividend");
        int dividend = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter divisor");
        int divisor = Convert.ToInt32(Console.ReadLine());
        //call method
        int[] result = Calculate(dividend, divisor);
        Console.WriteLine("The quotient is " + result[0]);
        Console.WriteLine("The remainder is " + result[1]);
    }
}