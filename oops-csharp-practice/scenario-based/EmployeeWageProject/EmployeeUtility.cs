using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWage.EmployeeWage;

namespace EmployeeWage.EmployeeWage
{
    internal class EmployeeUtility : IEmployee 
    {
        private Employee[] employee = new Employee[10];
        int countEmployee = 0;
        //private Employee employee;

        //method to add the employee
        public void AddEmployees()
        {
            if (countEmployee >= employee.Length)
            {
                Console.WriteLine("!!vacancy full!!");

            }
            else
            {


                Employee emp = new Employee();
                Console.Write("Enter the name of the Employee: ");
                emp.SetName(Console.ReadLine());

                Console.Write("Assign the Employee Id: ");
                emp.SetId(Console.ReadLine());

                employee[countEmployee] = emp;
                countEmployee++;
                Console.WriteLine("-----------Employee added successfully---------");
            }
        }

        //method to check the attendance
        public void CheckAttendance()
        {
            Random random = new Random();
            for (int i = 0; i < countEmployee; i++)
            {
                int check = random.Next(0, 2);
                if (check == 1) Console.WriteLine(employee[i].GetName() + " is Present");
                else Console.WriteLine(employee[i].GetName() + " is Absent");
            }
        }


    }
}
