using System;
using System.IO;
using System.Linq;

class ReadAndCount
{
    static void Main()
    {
        string filePath = "employees.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        int recordCount = 0;

        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();

            while (