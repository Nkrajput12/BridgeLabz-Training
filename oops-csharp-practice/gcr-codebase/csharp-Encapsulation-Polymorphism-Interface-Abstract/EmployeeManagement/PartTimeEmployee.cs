using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.EmployeeManagement
{
    public class PartTimeEmployee : Employee
    {
        private double hourlyRate;
        private int hoursWorked;

        public double HourlyRate
        {
            get { return hourlyRate; }
            set { hourlyRate = value; }
        }

        public int HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; }
        }

        public PartTimeEmployee(int id, string name, double hourlyRate, int hoursWorked)
            : base(id, name, 0)
        {
            hourlyRate = hourlyRate;
            hoursWorked = hoursWorked;
        }

        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }
}
