using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWage.EmployeeWage;

namespace EmployeeWage.EmployeeWage
{
    internal class Employee 
    {
        private string Name;
        public void SetName(string i)
        {
            Name = i;

        }
        public string GetName()
        {
            return Name;
        }
        private string Id {  get; set; }
        public void SetId(string i)
        {
            Id = i;

        }
        public string GetId()
        {
            return Id;
        }

        private double DailyWage = 800;

        private double HourlyWage = 100;


        public override string ToString()
        {
            return $"Employee: Name = {Name}, Id = {Id}";
        }

        

    }
}
