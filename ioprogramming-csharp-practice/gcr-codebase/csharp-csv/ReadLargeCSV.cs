using System;
using System.IO;

class ReadLargeCSV
{
    static void Main()
    {
        int count = 0;
        using (var reader = new StreamReader("large_data.csv"))
        {
            while (reader.ReadLine() != null)
            {
                count++;
                if (count % 100 == 0)
                {
                    Console.WriteLine($"Processed {count} records...");
                }
            }
        }
        Console.WriteLine($"Final Count: {count}");
    }
}