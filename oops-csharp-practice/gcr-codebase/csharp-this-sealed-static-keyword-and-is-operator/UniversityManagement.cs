using System;

class Student
{
    static string UniversityName = "Global Tech University"; // static variable shared among all students
    static private int totalStudents = 0; // private static variable to track enrollment safely

    public string Name;
    public readonly int RollNumber; // use readonly to prevent roll number changes after assignment
    public double Grade;

    public Student(string Name, int RollNumber, double Grade) // constructor to initialize values
    {
        this.Name = Name; // using 'this' to refer to the class field
        this.RollNumber = RollNumber; // assigning the readonly roll number
        this.Grade = Grade;
        totalStudents++; // increment the total student count
    }

    public void Display() // method to display student details
    {
        Console.WriteLine("University Name = " + UniversityName);
        Console.WriteLine("Student Name = " + Name);
        Console.WriteLine("Roll Number = " + RollNumber);
        Console.WriteLine("Grade = " + Grade);
        //Console.WriteLine("------------------------------");
    }

    public void GetTotalStudents() // method to get the total number of students
    {
        Console.WriteLine("Total students enrolled = " + totalStudents);
    }
}

class ManagementSystem // application class
{
    public static void Main(string[] args)
    {
        Student s1 = new Student("Alice", 101, 3.8); // create first object
        Student s2 = new Student("Bob", 102, 3.5); // create second object

        if (s1 is Student && s2 is Student) // check if objects are instances of the Student class
        {
            Console.WriteLine("Verification: Objects are instances of Student class");
            s1.Display(); // call method to display first student details
            s2.Display(); // call method to display second student details
        }

        s1.GetTotalStudents(); // get the total count using an instance
    }
}