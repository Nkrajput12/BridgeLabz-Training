using System;
using System.Reflection;

namespace AttributePractice
{
    // 1. Define the Custom Attribute
    // [AttributeUsage] restricts where this can be used (Methods in this case)
    [AttributeUsage(AttributeTargets.Method)]
    public class ImportantMethodAttribute : Attribute
    {
        public string Level { get; }

        // Constructor with a default value for the 'Level' parameter
        public ImportantMethodAttribute(string level = "HIGH")
        {
            Level = level;
        }
    }

    // 2. Apply it to methods
    public class BusinessLogic
    {
        [ImportantMethod("CRITICAL")]
        public void ProcessPayment()
        {
            Console.WriteLine("Processing payment...");
        }

        [ImportantMethod] // Uses the default "HIGH"
        public void SendEmail()
        {
            Console.WriteLine("Sending email...");
        }

        public void LogActivity()
        {
            Console.WriteLine("Logging activity...");
        }
    }

    class Program
    {
        static void Main()
        {
            Type type = typeof(BusinessLogic);
            Console.WriteLine($"--- Scanning {type.Name} for Important Methods ---\n");

            // 3. Retrieve and print annotated methods using Reflection
            foreach (MethodInfo method in type.GetMethods())
            {
                // Check if the method has our specific attribute
                var attribute = method.GetCustomAttribute<ImportantMethodAttribute>();

                if (attribute != null)
                {
                    Console.WriteLine($"[IMPORTANT] Method: {method.Name}");
                    Console.WriteLine($"            Priority Level: {attribute.Level}");
                    Console.WriteLine("----------------------------------");
                }
            }

            Console.ReadKey();
        }
    }
}