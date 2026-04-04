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

        public void ShowDailyWages()
        {
            Random random = new Random();

            for (int i = 0; i < countEmployee; i++)
            {
                Employee emp = employee[i];
                int check = random.Next(0, 3); // 0 = Absent, 1 = Part-Time, 2 = Full-Time

                int workingHours = 0;
                string status = "";

                // UC 4: Switch Case logic directly inside the loop
                switch (check)
                {
                    case 1:
                        workingHours = emp.PartTimeHour;
                        status = "Part-Time";
                        break;
                    case 2:
                        workingHours = emp.FullDayHour;
                        status = "Full-Time";
                        break;
                    default:
                        workingHours = 0;
                        status = "Absent";
                        break;
                }

                // Calculation: $DailyWage = Hours \times Rate$
                double DailyWage = workingHours * emp.HourlyWage;

                Console.WriteLine($"Name: {emp.GetName()} | Status: {status} | Wage: {DailyWage}");
            }
        }


        //method to calculate the monthly wages
        // Method for Month (UC 6 Logic) check for condition
        public void CalculateMonthlyWage()
        {
            Random random = new Random();
            for (int i = 0; i < countEmployee; i++)
            {
                Employee emp = employee[i];
                int totalHours = 0;
                int totalDays = 0;

                while (totalDays < 20 && totalHours < 100)
                {
                    totalDays++;
                    int check = random.Next(0, 3);
                    int dailyHours = 0;

                    switch (check)
                    {
                        case 1: dailyHours = emp.PartTimeHour; break;
                        case 2: dailyHours = emp.FullDayHour; break;
                        default: dailyHours = 0; break;
                    }

                    if (totalHours + dailyHours > 100) dailyHours = 100 - totalHours;
                    totalHours += dailyHours;
                }
                Console.WriteLine($"Name: {emp.GetName()} | Days: {totalDays} | Hours: {totalHours} | Total Wage: {totalHours * emp.HourlyWage}");
            }
        }



    }
}


    

