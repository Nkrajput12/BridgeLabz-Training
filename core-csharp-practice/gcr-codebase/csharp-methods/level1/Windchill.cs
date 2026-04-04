using System;
class Windchill
{
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the temperature");
        double temp = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the wind speed");
        double windSpeed = Convert.ToDouble(Console.ReadLine());

        //call method and print result
        Console.WriteLine("The Wind Chill Index is " + WindChill(temp, windSpeed));
    }

    //method to calculate wind chill
    public static double WindChill(double temp, double windSpeed)
    {
        double windChill = windChill = 35.74 + 0.6215 * temp + (0.4275 * temp - 35.75) * windSpeed*0.16;
        return windChill;
    }
}
    
    

