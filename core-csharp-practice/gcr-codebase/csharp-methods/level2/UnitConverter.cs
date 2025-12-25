using System;
class UnitConverter
{
    //method to convert km to miles
    public static double Kmtomiles(double km)
    {
        double miles = km * 0.621371;
        return  miles;
    }

    //method to convert miles to km
    public static double Milestokm(double miles)
    {
        double km = miles / 0.621371;
        return km;
    }

    //method to convert meter to feet
    public static double Metertofeet(double meter)
    {
        double feet = meter * 3.28084;
        return feet;
    }

    //method to convert feet to meter

    public static double Feettometer(double feet)
    {
        double meter = feet / 3.28084;
        return meter;
    }

    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the value in km");
        double km = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the value in meter");
        double meter = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the value in miles");
        double miles = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the value in feet");
        double feet = Convert.ToDouble(Console.ReadLine());


        //call method and print result
        double kmtoMiles = Kmtomiles(km);
        Console.WriteLine(km + " km is equal to " + kmtoMiles + " miles"); //km to miles

        double milestokm = Milestokm(miles);
        Console.WriteLine(miles + " miles is equal to " + milestokm + " km");// miles to km

        double metertofeet = Metertofeet(meter);
        Console.WriteLine(meter + " meter is equal to " + metertofeet + " feet");// meter to feet

        double feettometer = Feettometer(feet);
        Console.WriteLine(feet + " feet is equal to " + feettometer + " meter");// feet to meter
    }
}
