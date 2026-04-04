using System;
public class TemperatureConversion {

    public static void Main(String[] args) {
        float Celsius = 45;

        float fahrenheit = (Celsius*9/5) + 32;
        Console.WriteLine(fahrenheit);
    }
}