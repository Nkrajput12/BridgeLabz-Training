//Question Make Employee Management System
﻿using System;

class Employee
{
    public static void Main(string[] args)
    {
        Employee ob = new Employee();
        string[,] employee = new string[5, 3]; // Stores: [Name, ID, Salary]
        int employeesNumber = 0;
        int pass = 1234;

        while (true)
        {
            Console.WriteLine("\n--- MAIN MENU ---");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. User Login");
            Console.WriteLine("3. Exit");
            int mainChoice = Convert.ToInt32(Console.ReadLine());

            switch (mainChoice)
            {
                case 1:
                    Console.WriteLine("Enter pass:");
                    int pass1 = Convert.ToInt32(Console.ReadLine());
                    if (pass1 == pass)
                    {
                        ob.Admin(ref employee, ref employeesNumber);
                    }
                    else
                    {
                        Console.WriteLine("Wrong pass");
                    }
                    break;

                case 2:
                    ob.User(employee, employeesNumber);
                    break;

                case 3:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
        }
    }

    // method to add the employees
    public void Add(ref string[,] employee, ref int employeesNumber)
    {
        if (employeesNumber < 5)
        {
            Console.WriteLine("Enter the name of the employee");
            employee[employeesNumber, 0] = Console.ReadLine();
            Console.WriteLine("Enter the id of the employee");
            employee[employeesNumber, 1] = Console.ReadLine();
            Console.WriteLine("Enter the initial salary");
            employee[employeesNumber, 2] = Console.ReadLine();

            Console.WriteLine("----Employee added successfully----");
            employeesNumber++;
        }
        else
        {
            Console.WriteLine("Maximum limit of 5 employees reached.");
        }
    }

    // method to display all the employees
    void DisplayEmp(string[,] employee, int employeesNumber)
    {
        Console.WriteLine("----------details of all employees are---------- ");
        for (int i = 0; i < employeesNumber; i++)
        {
            Console.WriteLine("Name = " + employee[i, 0] + " Id = " + employee[i, 1] + " current salary = " + employee[i, 2]);
        }
    }

    // method to find the salary after leave
    void Leave(ref string[,] employee, int employeesNumber)
    {
        Console.WriteLine("enter the number of days absent:");
        int days = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter the id of the employee");
        string id = Console.ReadLine();

        double deduction = 0;
        for (int i = 0; i < employeesNumber; i++)
        {
            if (employee[i, 1] == id)
            {
                double salary = Convert.ToDouble(employee[i, 2]);
                double dailyWage = salary / 30;
                deduction = days * dailyWage;
            }
        }
        Console.WriteLine("the amount deducted from salary = " + deduction);
    }

    // method to find the highest salary
    void HighestSalary(string[,] employee, int employeesNumber)
    {
        if (employeesNumber == 0) return;
        double max = 0;
        int index = 0;
        for (int i = 0; i < employeesNumber; i++)
        {
            double currentSal = Convert.ToDouble(employee[i, 2]);
            if (currentSal > max)
            {
                max = currentSal;
                index = i;
            }
        }
        Console.WriteLine($"Highest Salary is {max} earned by {employee[index, 0]} (ID: {employee[index, 1]})");
    }

    void Admin(ref string[,] employee, ref int employeesNumber)
    {
        Employee ob = new Employee();
        Console.WriteLine("-------Welcome admin-------");
        bool exitAdmin = false;
        while (!exitAdmin)
        {
            Console.WriteLine("\nAdmin Menu:");
            Console.WriteLine("1 to add employee");
            Console.WriteLine("2 to see all employee details");
            Console.WriteLine("3 to find the salary deduction");
            Console.WriteLine("4 to find highest salary");
            Console.WriteLine("5 to logout");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ob.Add(ref employee, ref employeesNumber);
                    break;
                case 2:
                    ob.DisplayEmp(employee, employeesNumber);
                    break;
                case 3:
                    ob.Leave(ref employee, employeesNumber);
                    break;
                case 4:
                    ob.HighestSalary(employee, employeesNumber);
                    break;
                case 5:
                    exitAdmin = true;
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
        }
    }

    void User(string[,] employee, int employeesNumber)
    {
        Console.WriteLine("-----Welcome user----------");
        Console.WriteLine("Enter your Employee ID to login:");
        string id = Console.ReadLine();
        int empIdx = -1;

        // Find the index of the logged-in user
        for (int i = 0; i < employeesNumber; i++)
        {
            if (employee[i, 1] == id)
            {
                empIdx = i;
                break;
            }
        }

        if (empIdx != -1)
        {
            bool exitUser = false;
            while (!exitUser)
            {
                Console.WriteLine($"\nWelcome {employee[empIdx, 0]}!");
                Console.WriteLine("1. View My Profile");
                Console.WriteLine("2. Check Daily Wage");
                Console.WriteLine("3. Mark Attendance");
                Console.WriteLine("4. Logout");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"ID: {employee[empIdx, 1]} | Name: {employee[empIdx, 0]} | Salary: {employee[empIdx, 2]}");
                        break;
                    case 2:
                        double daily = Convert.ToDouble(employee[empIdx, 2]) / 30;
                        Console.WriteLine("Your Daily Wage is: " + daily);
                        break;
                    case 3:
                        Console.WriteLine("Attendance marked for: " + DateTime.Now.ToShortDateString());
                        break;
                    case 4:
                        exitUser = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Employee ID not found.");
        }
    }
}
