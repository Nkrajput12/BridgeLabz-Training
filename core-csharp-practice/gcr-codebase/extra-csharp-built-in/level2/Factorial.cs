using System;
class Factorial
{
    //method to calculate factorial
    public static int GetFactorial(int num)
    {
        if(num == 1 || num == 0) return 1;
        else return num*GetFactorial(num-1);

    }
    // method to take input
    public static int Input()
    {
        //taking input
        Console.Write("Enter the num");
        return Convert.ToInt32(Console.ReadLine());
    }

    //main method{
    public static void Main(string[] args)
    {
        int num  = Input();

        int fact = GetFactorial(num);

        Console.WriteLine("The factorial of "+num+" is "+fact);


    }
}
