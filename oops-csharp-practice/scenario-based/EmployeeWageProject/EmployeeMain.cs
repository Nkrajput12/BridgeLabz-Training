using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWage.EmployeeWage;

namespace EmployeeWage.EmployeeWage
{
    internal class EmployeeMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("----------Employee Wage programm----------");
            EmployeeMenu employeeMenu = new EmployeeMenu();

            employeeMenu.Run();
        }
    }
}
