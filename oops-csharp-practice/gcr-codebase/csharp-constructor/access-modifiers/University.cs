using System;

class Student
{
    public int rollNumber;       // Anyone can see this
    protected string name;       // Only this class and its "children" can see this
    private double CGPA;         // access only in current class

    public Student(int rollNumber, string name, double CGPA)
    {
        this.rollNumber = rollNumber;
        this.name = name;
        this.CGPA = CGPA;
    }

    // method to update cgpa
    public void UpdateCGPA(double newCGPA)
    {
        if (newCGPA >= 0 && newCGPA <= 10) // Small check to make sure it's valid
            this.CGPA = newCGPA;
    }

    public double GetCGPA() => this.CGPA;
}

class PostgraduateStudent : Student
{
    public PostgraduateStudent(int roll, string name, double cgpa) : base(roll, name, cgpa) { }

    public void ShowDetails()
    {
        // I can access 'name' because it's protected
        // I cannot access 'CGPA' directly here!
        Console.WriteLine($"PG Student: {name} (Roll: {rollNumber})");
    }
}

class Application
{
    public static void Main()
    {
        PostgraduateStudent pg = new PostgraduateStudent(101, "Aryan", 8.5);
        pg.ShowDetails();

        pg.UpdateCGPA(9.2); // Changing private data through a public method
        Console.WriteLine("Updated CGPA: " + pg.GetCGPA());
    }
}