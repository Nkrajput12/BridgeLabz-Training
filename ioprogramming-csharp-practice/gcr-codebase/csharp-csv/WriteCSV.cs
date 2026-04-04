using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string filePath = "employees.csv";

        var employees = new List<string[]>
        {
            new string[] { "ID", "Name", "Department", "Salary" },
            new string[] { "1", "Alice Munro", "Engineering", "85000" },
            new string[] { "2", "Bob Wilson", "Marketing", "62000" },
            new string[] { "3", "Catherine Lee", "HR", "58000" },
            new string[] { "4", "David Miller", "Sales", "71000" },
            new string[] { "5", "Emma Stone", "Engineering", "92000" }
        };

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var employee in employees)
            {
                writer.WriteLine(string.Join(",", employee));
            }
        }

        Console.WriteLine("Data successfully written to " + filePath);
    }
}