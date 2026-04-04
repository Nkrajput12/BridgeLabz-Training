using System;

public class Program
{
    public static void Main(string[]args)
    {   
        CitizenUtil util = new CitizenUtil();

        util.register();

        Console.WriteLine("Enter Name To Search:");
        string name = Console.ReadLine() ?? "";
        util.SearchCitizen(name);

        Console.WriteLine("Enter ID to Update Income:");
        int Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter New Income:");
        double income = Convert.ToDouble(Console.ReadLine());

        util.UpdateIncome(Id,income);
    }
}