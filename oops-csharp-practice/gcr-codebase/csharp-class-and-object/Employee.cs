using System;
class Employee
{
    private string name;
    private string id;
    private double salary;

    //method to set the Employee details
    public void SetEmpDetails(string name, string id, double salary)
    {
        this.name = name;
        this.id = id;
        this.salary = salary;
    }

    //method to display Employee details
    public void Display()
    {
        Console.WriteLine("EMP name  : " + name);
        Console.WriteLine("EMP ID    : " + id);
        Console.WriteLine("salary    : " + salary);
    }
}

class ShowBook
{
    static void Main()
    {
        //make object of Employee class 
        Employee b = new Employee();
        //take the input from user
        Console.Write("Enter the Employee name ");
        string name = Console.ReadLine() ?? ""; // store the name of the employee in this 
        Console.Write("Enter the Employee id ");
        string id = Console.ReadLine() ?? ""; //store the emp id
        Console.Write("Enter the salary ");
        double salary = Convert.ToDouble(Console.ReadLine()); //store the salary of the employee

        b.SetEmpDetails(name, id, salary);  // calling the function to set details
        b.Display(); //call the dispaly method to show the details
    }
}