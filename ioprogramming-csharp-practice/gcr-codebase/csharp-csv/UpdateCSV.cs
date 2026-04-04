using System;
using System.IO;
using System.Collections.Generic;

class UpdateCSV
{
    static void Main()
    {
        string inputPath = "employees.csv";
        string outputPath = "updated_employees.csv";
        List<string> updatedLines = new List<string>();

        if (!File.Exists(inputPath)) return;

        using (var reader = new StreamReader(inputPath))
        {
            string header = reader.ReadLine();
            updatedLines.Add(header);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (values.Length == 4)
                {
                    string id = values[0];
                    string name = values[1];
                    string dept = values[2];

                    if (dept == "Engineering" || dept == "IT")
                    {
                        double salary = double.Parse(values[3]);
                        salary *= 1.10;
                        updatedLines.Add($"{id},{name},{dept},{salary:F2}");
                    }
                    else
                    {
                        updatedLines.Add(line);
                    }
                }
            }
        }

        File.WriteAllLines(outputPath, updatedLines);
        Console.WriteLine("Update complete. Saved to " + outputPath);
    }
}