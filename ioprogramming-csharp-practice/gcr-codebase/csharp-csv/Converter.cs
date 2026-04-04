using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

public class Student1
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Converter
{
    public static void JsonToCsv(string jsonPath, string csvPath)
    {
        var jsonString = File.ReadAllText(jsonPath);
        var students = JsonSerializer.Deserialize<List<Student>>(jsonString);

        using (var writer = new StreamWriter(csvPath))
        {
            writer.WriteLine("Id,Name");
            foreach (var s in students) writer.WriteLine($"{s.Id},{s.Name}");
        }
    }

    public static void CsvToJson(string csvPath, string jsonPath)
    {
        var lines = File.ReadAllLines(csvPath).Skip(1);
        var students = lines.Select(l => new Student
        {
            Id = int.Parse(l.Split(',')[0]),
            Name = l.Split(',