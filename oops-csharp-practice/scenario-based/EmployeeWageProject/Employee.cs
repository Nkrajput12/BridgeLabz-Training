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

        public double HourlyWage = 100;
        public int FullDayHour = 8;
        public double DailyWage = 0;


        public override string ToString()
        {
            return $"Employee: Name = {Name}, Id = {Id}";
        }

        

    }
}
