using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.EmployeeManagement
{
    class EmpMain
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of employees to register: ");
            int count = int.Parse(Console.ReadLine());

            // Using an Array instead of a List
            Employee[] employees = new Employee[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("\n--- Entering Details for Employee " + (i + 1) + " ---");

                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Department: ");
                string dept = Console.ReadLine();

                Console.Write("Type (1 for Full-Time, 2 for Part-Time): ");
                int type = int.Parse(Console.ReadLine());

                if (type == 1)
                {
                    Console.Write("Enter Base Salary: ");
                    double salary = double.Parse(Console.ReadLine());
                    Console.Write("Enter Monthly Bonus: ");
                    double bonus = double.Parse(Console.ReadLine());

                    employees[i] = new FullTimeEmployee(id, name, salary, bonus);
                }
                else
                {
                    Console.Write("Enter Hourly Rate: ");
                    double rate = double.Parse(Console.ReadLine());
                    Console.Write("Enter Hours Worked: ");
                    int hours = int.Parse(Console.ReadLine());

                    employees[i] = new PartTimeEmployee(id, name, rate, hours);
                }

                // Assign the department using the interface method
                employees[i].AssignDepartment(dept);
            }

            Console.WriteLine("\n\n=== FINAL PAYROLL REPORT ===");

            // Iterate through the array using polymorphism
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    employees[i].DisplayDetails();
                }
            }

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
