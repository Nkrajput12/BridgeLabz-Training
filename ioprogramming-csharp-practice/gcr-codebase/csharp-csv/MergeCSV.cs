using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class MergeCSV
{
    static void Main()
    {
        var file1 = File.ReadLines("students1.csv").Skip(1)
            .Select(l => l.Split(',')).ToDictionary(v => v[0], v => $"{v[1]},{v[2]}");

        var file2 = File.ReadLines("students2.csv").Skip(1)
            .Select(l => l.Split(',')).ToDictionary(v => v[0], v => $"{v[1]},{v[2]}");

        using (var writer = new StreamWriter("merged_students.csv"))
        {
            writer.WriteLine("ID,Name,Age,Marks,Grade");
            foreach (var id in file1.Keys)
            {
                if (file2.ContainsKey(id))
                    writer.WriteLine($"{id},{file1[id]},{file2[id]}");
            }
        }
    }
}