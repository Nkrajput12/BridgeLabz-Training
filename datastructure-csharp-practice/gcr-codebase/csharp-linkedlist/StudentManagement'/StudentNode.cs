using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.StudentManagement_
{
    public class StudentNode
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Grade { get; set; }
        public StudentNode Next { get; set; } // Reference to the next student

        public StudentNode(int roll, string name, int age, char grade)
        {
            RollNumber = roll;
            Name = name;
            Age = age;
            Grade = grade;
            Next = null;
        }
    }
}
