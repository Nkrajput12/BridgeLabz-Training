using System;
class Calculator
{   

    //method for Calculation
    public static void Calculate(double first, double second,string op)
    {
        switch (op)
        {
            case "+":
                Console.WriteLine(first + second);
                break;

            case "-":
                Console.WriteLine(first - second);
                break;

            case "*":
                Console.WriteLine(first * second);
                break;

            case "/":
                if (second != 0)
                {
                    Console.WriteLine(first / second);
                }
                else
                {
                    Console.WriteLine("Cannot divide by zero");
                }
                break;

            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
    public static void Main(string[] args)
    {

        //taking input
        Console.WriteLine("Enter first number:");
        double first = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        double second = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter operator (+, -, *, /):");
        string op = Console.ReadLine() ?? "";

        Calculate(first, second, op);
        
    }
}