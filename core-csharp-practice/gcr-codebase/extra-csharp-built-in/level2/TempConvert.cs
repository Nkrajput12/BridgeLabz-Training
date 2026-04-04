using System;

class TempConvert
{
    //method to convert fahrenheit to celsius
    public static float ConvertFtoC(float f)
    {
        return  (f - 32) * 5 / 9;
    }

    //main method
    public static void Main(string[] args)
    {
        //taking input
        Console.Write("Enter temperatur in Fahrenheit: ");
        float f = Convert.ToSingle(Console.ReadLine());

        float celsius = ConvertFtoC(f);
        Console.WriteLine("the temperature in Celsius is "+celsius);
    }
}
