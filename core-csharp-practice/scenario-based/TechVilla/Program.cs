using System;

public class Program
{
    public static void Main(string[]args)
    {
        Citizen[] citizen = new Citizen[5];
        int citizenCount = 0;

        Console.WriteLine("How many people you want to Register");
        int n = Convert.ToInt32(Console.ReadLine());
        for(int i = 0;i<n;i++)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            if(age < 1){
                Console.WriteLine("Invalid Age");
                i--;
                continue;
            }
            Console.Write("Income: ");
            double income = Convert.ToDouble(Console.ReadLine());
            Console.Write("Residency years: ");
            int year = Convert.ToInt32(Console.ReadLine());

            int id = citizenCount++;

            citizen[citizenCount] = new Citizen(id,name,age,income,year);

            citizen[citizenCount].Display();
        }
        Console.WriteLine("Citizens added successfully");

        int[,] cityMap = new int[5,3];
        cityMap[0,0] = citizenCount;
        Console.WriteLine("Citizen Mapped");


        

    }
}