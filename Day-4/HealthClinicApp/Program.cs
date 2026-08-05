using System;
using HealthClinic.Menu;
public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();

        Console.WriteLine("App is running");

        menu.Run();
    }
}