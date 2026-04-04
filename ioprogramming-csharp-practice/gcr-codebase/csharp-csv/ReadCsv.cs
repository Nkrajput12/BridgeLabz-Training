using System;
using System.IO;

class ReadCsv
{
    static void Main()
    {
        string filePath = "students.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        Console.WriteLine($"{"ID",-5} | {"Name",-15} | {"Age",-5} | {"Marks",-5}");
        Console.WriteLine(new string('-', 40));

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
                    Console.WriteLine($"{values[0].Trim(),-5} | {values[1].Trim(),-15} | {values[2].Trim(),-5} | {values[3].Trim(),-5}");
                }
            }
        }
    }
}