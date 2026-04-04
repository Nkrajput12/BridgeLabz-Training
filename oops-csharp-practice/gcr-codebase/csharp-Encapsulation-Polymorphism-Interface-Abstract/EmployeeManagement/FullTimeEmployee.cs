using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.EmployeeManagement
{
    public class FullTimeEmployee : Employee
    {
        private double Bonus;

        public double bonus
        {
            get { return Bonus; }
            set { Bonus = value; }
        }

        public FullTimeEmployee(int id, string name, double baseSalary, double bonus)
            : base(id, name, baseSalary)
        {
            Bonus = bonus;
        }

        public override double CalculateSalary()
        {
            return baseSalary + Bonus;
        }
    }
}
