using System;

class Employee
{
    public int employeeID;
    protected string department;
    private double salary;

    public Employee(int id, string dept, double sal)
    {
        this.employeeID = id;
        this.department = dept;
        this.salary = sal;
    }

    // Method to modify salary (maybe after a performance review!)
    public void UpdateSalary(double newSalary)
    {
        if (newSalary > 0) this.salary = newSalary;
    }

    public void ShowSalary() => Console.WriteLine("Salary is locked in the system.");
}

class Manager : Employee
{
    public Manager(int id, string dept, double sal) : base(id, dept, sal) { }

    public void PrintReport()
    {
        // Manager can see ID and Dept, but not the salary field directly
        Console.WriteLine($"Manager ID: {employeeID} handles {department} department.");
    }
}

class Application
{
    public static void Main()
    {
        Manager m = new Manager(501, "IT Operations", 75000);
        m.PrintReport();
        m.UpdateSalary(80000); // Admin/System updates the salary
        Console.WriteLine("Salary updated successfully.");
    }
}