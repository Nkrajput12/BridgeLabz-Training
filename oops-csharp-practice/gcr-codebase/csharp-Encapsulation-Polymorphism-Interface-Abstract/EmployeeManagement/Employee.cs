using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.EmployeeManagement
{
    public abstract class Employee : IDepartment
    {
        private int Id;
        private string Name;
        private double BaseSalary;
        private string DepartmentName;

        public int id { get { return Id; } set { Id = value; } }
        public string name { get { return Name; } set { Name = value; } }

        public double baseSalary { get { return BaseSalary; } set { BaseSalary = value; } }

        public Employee(int id, string name, double baseSalary)
        {
            this.id = id;
            this.name = name;
            BaseSalary = baseSalary;  
        }

        public abstract double CalculateSalary();

        public void DisplayDetails()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Employee ID: " + Id);
            Console.WriteLine("Name       : " + Name);
            Console.WriteLine("Department : " + GetDepartmentName());
            Console.WriteLine("Total Pay  : " + CalculateSalary().ToString());
        }

        public void AssignDepartment(string deptName)
        {
            DepartmentName = deptName;
        }

        public string GetDepartmentName()
        {
            if (DepartmentName == null)
            {
                return "Not Assigned";
            }
            return DepartmentName;
        }
}
}
