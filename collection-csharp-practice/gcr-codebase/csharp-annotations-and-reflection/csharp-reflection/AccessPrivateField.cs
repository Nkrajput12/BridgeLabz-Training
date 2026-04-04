using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BridgeLabzTraining.csharp_annotations_and_reflection.csharp_reflection
{
    // class we want to inspect
    public class Person
    {
        private int age = 25;
    }
    internal class AccessPrivateField
    {
        public static void Main()
        {
            Person person = new Person();
            //get the type of the Person class
            Type type = typeof(Person);
            // Accessing the private field 'age' using reflection
            var fieldInfo = type.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                int ageValue = (int)fieldInfo.GetValue(person);
                Console.WriteLine($"Private field 'age' value: {ageValue}");
            }
            else
            {
                Console.WriteLine("Field not found.");
            }
        }
    }
}
