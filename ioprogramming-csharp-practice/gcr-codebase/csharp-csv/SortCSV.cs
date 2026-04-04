using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

class SortCSV
{
    static void Main()
    {
        string filePath = "employees.csv";
        List<Employee> employeeList = new List<Employee>();

        if (!File.Exists(filePath)) return;

        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(',');
                if (values.Length == 4)
                {
                    employeeList.Add(new Employee
                    {
                        ID = values[0],
                        Name = values[1],
                        Department = values[2],
                        Salary = double.Parse(values[3])
                    });
                }
            }
        }

        var topEmployees = employeeList
            .OrderByDescending(e => e.Salary)
            .Take(5);

        Console.WriteLine($"{"Name",-15} | {"Department",-15} | {"Salary",-10}");
        Console.WriteLine(new string('-', 45));

        foreach (var emp in topEmployees)
        {
            Console.WriteLine($"{emp.Name,-15} | {emp.Department,-15} | {emp.Salary,-10:C}");
        }
    }
}