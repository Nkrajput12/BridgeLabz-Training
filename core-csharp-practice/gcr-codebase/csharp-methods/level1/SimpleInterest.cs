using System;
class SimpleInterest
{
    public static void Main(string[] args)
    {
        //taking inputs from user
        Console.WriteLine("Enter Principal Amount");
        double principal = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Rate of Interest:");
        double rate = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Time in years");
        double time = Convert.ToDouble(Console.ReadLine());

        //call method and store the value inside interest variable
        double interest = CalculateSI(principal, rate, time);
        Console.WriteLine("Simple Interest: " + interest);
    }

    //method for calculating simpleinterest 
    static double CalculateSI(double p, double r, double t)
    {
        return (p * r * t) / 100; //formula of simple interest
    }
}
