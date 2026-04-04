using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_annotations_and_reflection.csharp_reflection
{

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Student()
        {
            Name = "Default Name";
            Age = 18;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
    internal class DynamicObjectcreation
    {
        public static void Main()
        {
            // Create an instance of Student using reflection
            Type studentType = typeof(Student);
            object studentInstance = Activator.CreateInstance(studentType);

            // Set properties using reflection
            studentType.GetProperty("Name").SetValue(studentInstance, "Ram");
            studentType.GetProperty("Age").SetValue(studentInstance, 20);

            // Display the student information
            Console.WriteLine(studentType.GetMethod("ToString").Invoke(studentInstance, null));
        }
    }
}
