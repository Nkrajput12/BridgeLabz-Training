using System;

class Bounus
{
    //method for generating random salary
    public static int[,] GenerateSalaryYears()
    {
        int[,] data = new int[10, 2];
        Random rnd = new Random();
        for (int i = 0; i < 10; i++)
        {
            data[i, 0] = rnd.Next(30000, 100000); //salary
            data[i, 1] = rnd.Next(1, 11); //years of service
        }
        return data;
    }

    //method for calulating new salary and bonus
    public static double[,] CalculateBonus(int[,] data)
    {
        double[,] newData = new double[10, 2];
        double bonus = 0;
        for (int i = 0; i < 10; i++)
        {
            if(data[i, 0] > 5)
            {
                bonus = data[i, 0] * 0.05;
            }
            else
            {
                bonus = data[i, 0] * 0.02;
            }
                newData[i, 0] = data[i, 0] + bonus;
            newData[i, 1] = bonus;
        }
        return newData;
    }

    //method for display results
    public static void Display(int[,] data, double[,] newData)
    {
        double totalOld = 0, totalNew = 0, totalBonus = 0;
        Console.WriteLine("Emp\tOldSalary\tYears\tBonus\tNewSalary");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i + 1}\t{data[i, 0]}\t\t{data[i, 1]}\t{newData[i, 1]:F2}\t{newData[i, 0]:F2}");
            totalOld += data[i, 0];
            totalNew += newData[i, 0];
            totalBonus += newData[i, 1];
        }
        Console.WriteLine($"Total\t{totalOld}\t\t-\t{totalBonus:F2}\t{totalNew:F2}");
    }

    static void Main()
    {
        int[,] data = GenerateSalaryYears();
        double[,] newData = CalculateBonus(data);
        Display(data, newData);
    }
}