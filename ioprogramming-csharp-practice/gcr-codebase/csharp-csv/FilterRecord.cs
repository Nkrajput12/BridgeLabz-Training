using System;
using System.IO;

class FilterRecord
{
    static void Main()
    {
        string filePath = "students.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        Console.WriteLine($"{"ID",-5} | {"Name",-15} | {"Marks",-5}");
        Console.WriteLine(new string('-', 30));

        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var values = line.Split(',');

                if (values.Length == 4)
                {
                    if (int.TryParse(values[3], out int marks) && marks > 80)
                    {
                        Console.WriteLine($"{values[0],-5} | {values[1],-15} | {values[3],-5}");
                    }
                }
            }
        }
    }
}