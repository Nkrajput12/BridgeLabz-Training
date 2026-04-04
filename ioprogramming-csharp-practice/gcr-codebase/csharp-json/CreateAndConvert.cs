using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class Car
{
    public string Model { get; set; }
    public int Year { get; set; }
}

public class Program
{
    public static void Main()
    {
        // 1.1 Create Student JSON (Anonymous Object)
        var student = new
        {
            name = "Alice",
            age = 20,
            subjects = new[] { "Math", "Science" }
        };
        string studentJson = JsonConvert.SerializeObject(student, Formatting.Indented);
        Console.WriteLine("Student JSON:\n" + studentJson);

        // 1.2 Convert Car Class to JSON
        Car myCar = new Car { Model = "Tesla Model 3", Year = 2024 };
        string carJson = JsonConvert.SerializeObject(myCar);
        Console.WriteLine("\nCar JSON: " + carJson);
    }
}