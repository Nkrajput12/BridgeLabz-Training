using System;
class UnitConverter3
{
    //method to convert ferhrenheit to celsius
    public static double F2C(double ferhrenheit)
    {
        double celsius = (ferhrenheit - 32) * 5 / 9;
        return celsius;
    }

    //method to convert celsius to ferhrenheit
    public static double C2F(double celsius)
    {
        double ferhrenheit = (celsius * 9 / 5) + 32;
        return ferhrenheit;
    }

    //method to covert pounds to kg
    public static double P2kg(double pounds)
    {
        double kg = pounds * 0.453592;
        return kg;
    }

    //method to convert kg to pounds
    public static double Kg2p(double kg)
    {
        double pounds = kg / 0.453592;
        return pounds;
    }

    //method to convert gallons to liters
    public static double G2l(double gallons)
    {
        double liters = gallons * 3.78541;
        return liters;
    }

    //method to convert liters to gallons
    public static double L2g(double liters)
    {
        double gallons = liters / 3.78541;
        return gallons;
    }

    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the value in ferhrenheit");
        double ferhrenheit = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the value in celsius");
        double celsius = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the value in pounds");
        double pounds = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the value in kg");
        double kg = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the value in gallons");
        double gallons = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the value in liters");
        double liters = Convert.ToDouble(Console.ReadLine());


        //call method and print result
        Console.WriteLine(ferhrenheit + " F is equal to " + F2C(ferhrenheit) + " C"); // ferhrenheit to celsius
        Console.WriteLine(celsius + " C is equal to " + C2F(celsius) + " F"); // celsius to ferhrenheit
        Console.WriteLine(pounds + " pounds is equal to " + P2kg(pounds) + " kg"); // pounds to kg
        Console.WriteLine(kg + " kg is equal to " + Kg2p(kg) + " pounds"); // kg to pounds
        Console.WriteLine(gallons + " gallons is equal to " + G2l(gallons) + " liters"); // gallons to liters
        Console.WriteLine(liters + " liters is equal to " + L2g(liters) + " gallons"); // liters to gallons
    }


}