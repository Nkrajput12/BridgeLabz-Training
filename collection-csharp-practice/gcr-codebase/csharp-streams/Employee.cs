using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// This is our blueprint for an Employee
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

class Program
{
    static void Main()
    {
        string fileName = "C:\\Users\\nkr88\\OneDrive\\Desktop\\file.txt";

        // Let's create a couple of employees to test with
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 101, Name = "Alice", Department = "IT", Salary = 75000 },
            new Employee { Id = 102, Name = "Bob", Department = "HR", Salary = 60000 }
        };

        try
        {

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(employees, options);

            // We write that string into a file
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine("Data saved!");



            Console.WriteLine("\nReading data back from the file...");

            // We read the text back from the file
            string loadedJson = File.ReadAllText(fileName);

            // We turn that text back into a List of Employee objects
            List<Employee> loadedEmployees = JsonSerializer.Deserialize<List<Employee>>(loadedJson);

            // Let's print them out to prove it worked!
            foreach (var emp in loadedEmployees)
            {
                Console.WriteLine($"ID: {emp.Id} | Name: {emp.Name} | Dept: {emp.Department} | Salary: ${emp.Salary}");
            }
        }
        catch (Exception ex)
        {
            // If the file is missing or corrupted, we catch the error here
            Console.WriteLine($"Oops! Something went wrong: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to close...");
        Console.ReadKey();
    }
}