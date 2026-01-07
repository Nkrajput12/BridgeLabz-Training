using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWage.EmployeeWage;

namespace EmployeeWage.EmployeeWage
{
    internal class EmployeeMenu
    {
        EmployeeUtility utility = new EmployeeUtility();

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("press 1 to add Emp");
                Console.WriteLine("press 2 to Check Attendance");
                Console.WriteLine("press 3 to calculate Daily employee Waged");
                Console.WriteLine("press 4 to exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        utility.AddEmployees();
                        break;
                    
                    case 2:
                        utility.CheckAttendance();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
