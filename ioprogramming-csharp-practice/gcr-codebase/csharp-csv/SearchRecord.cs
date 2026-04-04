using System;
using System.IO;

class SearchRecord
{
    static void Main()
    {
        string filePath = "employees.csv";
        Console.Write("Enter Employee Name to Search: ");
        string searchName = Console.ReadLine();
        bool found = false;

        if (!File.Exists(filePath)) return;

        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (values.Length == 4 && values[1].Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Department: {values[2]}");
                    Console.WriteLine($"Salary: {values[3]}");
                    found = true;
                    break;
                }
            }
        }

        if (!found) Console.WriteLine("Employee not found.");
    }
}