using System;
class UnitConverter2
{
    // method to convert Yards to feet
    public static double Yardstofeet(double yards)
    {
        double feet = yards * 3;
        return feet;
    }

    // method to convert feet to Yards
    public static double FeettoYards(double feet)
    {
        double yards = feet / 3;
        return yards;
    }

    //method to convert meter to inches
    public static double Metertoinches(double meter)
    {
        double inches = meter * 39.3701;
        return inches;
    }

    //method to convert inches to meter
    public static double Inchestometer(double inches)
    {
        double meter = inches / 39.3701;
        return meter;
    }
    //method to convert inches to cm
    public static double Inchestocm(double inches)
    {
        double cm = inches * 2.54;
        return cm;
    }

    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the value in yards");
        double yards = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the value in feet");
        double feet = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the value in meter");
        double meter = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the value in inches");
        double inches = Convert.ToDouble(Console.ReadLine());

        //call method and print result
        Console.WriteLine(yards + " yards is equal to " + Yardstofeet(yards) + " feet"); // yards to feet
        Console.WriteLine(feet + " feet is equal to " + FeettoYards(feet) + " yards"); // feet to yards
        Console.WriteLine(meter + " meter is equal to " + Metertoinches(meter) + " inches"); // meter to inches
        Console.WriteLine(inches + " inches is equal to " + Inchestometer(inches) + " meter"); // inches to meter
        Console.WriteLine(inches + " inches is equal to " + Inchestocm(inches) + " cm"); // inches to cm

    }
}

