using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class DeleteDuplicate
{
    static void Main()
    {
        var ids = new HashSet<string>();
        var duplicates = new List<string>();

        foreach (var line in File.ReadLines("data.csv").Skip(1))
        {
            var id = line.Split(',')[0];
            if (!ids.Add(id))
            {
                duplicates.Add(line);
            }
        }

        Console.WriteLine("Duplicate Records:");
        duplicates.ForEach(Console.WriteLine);
    }
}