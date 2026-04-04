using System;
class EmployeeMangement
{
    public static string CompanyName = "Ganga logistics"; // static company name shared accross all instances
    // decalring name id and designation for employee
    private string empName;
    private readonly string id; //readonly variable is use to prevent from modification
    private string designation;

    private static int totalEmployee = 0; //total employee track count of number of employee

    //constructor to intialize the value of name id and designaton 
    public EmployeeMangement(string empName, string id, string designation)
    {
        this.empName = empName;
        this.id = id;
        this.designation = designation;
        totalEmployee++;
    }

    // a static method to desplay the Employee number
    public static void DisplayEmployeeNumber()
    {
        Console.WriteLine("Total Employee = " + totalEmployee);
    }

    //method to display the details of the employee
    public void Display()
    {
        Console.WriteLine("Employee Name = " + empName);
        Console.WriteLine("Employee id = " + id);
        Console.WriteLine("Designation = "+ designation);
    }
    
}
class Company
{
    public static void Main(string[] args)
    {
        //creating the object
        EmployeeMangement emp1 = new EmployeeMangement("Raj", "12365", "programmer");

        EmployeeMangement.DisplayEmployeeNumber(); //this method is static so we can access it only by class name

       if(emp1 is EmployeeMangement) //check if the object is the instance of the class or not
        {
            Console.WriteLine("yes the object is the instance of the class");
            emp1.Display(); //method to display the employee details
        }
    }
}
