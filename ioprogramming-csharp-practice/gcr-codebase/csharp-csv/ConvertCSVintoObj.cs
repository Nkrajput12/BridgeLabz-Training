using System;
using System.Collections.Generic;
using System.IO;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Student{{ID={Id}, Name='{Name}', Age={Age}}}";
    }
}

class ConvertCSVintoObj

{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
        string filePath = "students.csv";

        if (!File.Exists(filePath)) return;

        using (StreamReader sr = new StreamReader(filePath))
        {
            sr.ReadLine();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] v = line.Split(',');
                students.Add(new Student(int.Parse(v[0]), v[1], int.Parse(v[2])));
            }
        }

        students.ForEach(s => Console.WriteLine(s));
    }
}