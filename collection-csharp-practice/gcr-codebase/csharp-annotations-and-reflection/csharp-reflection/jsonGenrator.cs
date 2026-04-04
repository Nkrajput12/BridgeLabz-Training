using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_annotations_and_reflection.csharp_reflection
{
    public class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;
        public bool IsRemote;

        public Employee(int id, string name, string dept, double salary, bool remote)
        {
            Id = id;
            Name = name;
            Department = dept;
            Salary = salary;
            IsRemote = remote;
        }
    }

    public static class MyJsonSerializer
    {
        public static string ToJson(object obj)
        {
            if (obj == null) return "null";

            Type type = obj.GetType();
            StringBuilder jsonBuilder = new StringBuilder();

            jsonBuilder.Append("{\n");

            // 1. Get all public instance fields
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];
                string name = field.Name;
                object value = field.GetValue(obj);

                // 2. Format the Key
                jsonBuilder.Append($"  \"{name}\": ");

                // 3. Format the Value based on its data type
                jsonBuilder.Append(FormatValue(value));

                // 4. Handle commas (no comma after the last item)
                if (i < fields.Length - 1)
                {
                    jsonBuilder.Append(",");
                }
                jsonBuilder.Append("\n");
            }

            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        private static string FormatValue(object value)
        {
            if (value == null) return "null";

            // If it's a string, wrap it in quotes
            if (value is string)
            {
                return $"\"{value}\"";
            }

            // If it's a boolean, make it lowercase (JSON standard)
            if (value is bool b)
            {
                return b.ToString().ToLower();
            }

            // For numbers (int, double, etc.), return as is
            return value.ToString();
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a test object
            Employee emp = new Employee(101, "Sarah Connor", "Operations", 75000.50, true);

            // Convert to JSON using our Reflection-based Serializer
            string jsonResult = MyJsonSerializer.ToJson(emp);

            Console.WriteLine("Generated JSON String:");
            Console.WriteLine("-----------------------");
            Console.WriteLine(jsonResult);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
