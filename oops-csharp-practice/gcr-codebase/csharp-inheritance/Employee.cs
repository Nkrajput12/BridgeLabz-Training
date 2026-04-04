using System;

// Base Class 
class Employees
{
    //declaring variables
    public string Name;
    public int Id;
    public double Salary;

    //constructor
    public Employees(string Name, int Id, double Salary)
    {
        this.Name = Name;
        this.Id = Id;
        this.Salary = Salary;
    }

    // 'virtual' allows us to add more info in the subclasses later
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"ID: {Id} | Name: {Name} | Salary: {Salary:C}");
    }
}

// Subclass: Manager
class Manager : Employees
{
    //team size under manager
    public int TeamSize;

    // We use 'base' to pass the name, id, and salary up to the Employee constructor
    public Manager(string name, int id, double salary, int teamSize)
        : base(name, id, salary)
    {
        this.TeamSize = teamSize;
    }

    //method to display details for manager
    public override void DisplayDetails()
    {
        // base.DisplayDetails() display details from employee class
        base.DisplayDetails();
        Console.WriteLine($"Role: Manager | Team Size: {TeamSize}");
    }
}

// Subclass: Developer
class Developer : Employees
{
    //variable to store devloper skills
    public string ProgrammingLanguage;

    //constructor of devloper class and use base for employee
    public Developer(string name, int id, double salary, string language)
        : base(name, id, salary)
    {
        this.ProgrammingLanguage = language;
    }

    //display the details
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Role: Developer | Language: {ProgrammingLanguage}");
    }
}

// Subclass: Intern
class Intern : Employees
{
    public string InternshipDuration;

    public Intern(string name, int id, double salary, string duration)
        : base(name, id, salary)
    {
        this.InternshipDuration = duration;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Role: Intern | Duration: {InternshipDuration}");
    }
}

class Application
{
    public static void Main(string[] args)
    {
        // Creating specific employee types
        Manager m = new Manager("Nkraj", 1001, 90000, 10); //creating object of manager class
        Developer d = new Developer("mohan", 2002, 75000, "C#"); //creating object of developer class
        Intern i = new Intern("sohan", 3003, 20000, "6 Months"); // creating object for intern class


        //calling display method to all objects
        Console.WriteLine("--- Employee Records ---");
        m.DisplayDetails();
        Console.WriteLine("------------------------");
        d.DisplayDetails();
        Console.WriteLine("------------------------");
        i.DisplayDetails();
    }
}