using System;

public class Program
{
    public static void Main(string[]args)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Income: ");
        double income = Convert.ToDouble(Console.ReadLine());
        Console.Write("Residency years: ");
        int year = Convert.ToInt32(Console.ReadLine());


        Citizen citizen = new Citizen(name,age,income,year);

        citizen.Display();
    }
}