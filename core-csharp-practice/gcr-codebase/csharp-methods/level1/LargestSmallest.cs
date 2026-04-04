using System;
class LargestSmallest
{
    //method to find largest and smallest among three numbers
    public static int[] check(int a, int b, int c)
    {
        int largest, smallest;

        //checking for largest
        if (a >= b && a >= c)
        {
            largest = a;
        }
        else if (b >= a && b >= c)
        {
            largest = b;
        }
        else
        {
            largest = c;
        }

        //checking for smallest
        if (a <= b && a <= c)
        {
            smallest = a;
        }
        else if (b <= a && b <= c)
        {
            smallest = b;
        }
        else
        {
            smallest = c;
        }
        return new int[] { largest, smallest }; 

    }
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter first number");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number");
        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter third number");
        int num3 = Convert.ToInt32(Console.ReadLine());
        //call method

        int[] result = check(num1, num2, num3);
        Console.WriteLine("The largest number is " + result[0]);
        Console.WriteLine("The smallest number is " + result[1]);

    }
}