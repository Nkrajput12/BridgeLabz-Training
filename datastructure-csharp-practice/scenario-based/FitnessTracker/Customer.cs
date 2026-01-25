using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.FitnessTracker
{
    public  class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int StepCount { get; set; }

        public Customer(string name, int age)
        {
            Name = name;
            Age = age;
            StepCount = 0;
        }

    }
}
