using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BridgeLabzTraining.csharp_annotations_and_reflection.csharp_reflection
{
    public class Calculator
    {
        // This is private!
        private int Multiply(int a, int b)
        {
            return a * b;
        }
    }
    internal class InvokeMethod
    {
        public static void Main()
        {
            Calculator calc = new Calculator();
            // Get the type of the Calculator class
            Type type = typeof(Calculator);
            // Get the private method 'Multiply' using reflection
            MethodInfo methodInfo = type.GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);
            if (methodInfo != null)
            {
                // Invoke the method on the calc instance with parameters 5 and 10
                object result = methodInfo.Invoke(calc, new object[] { 5, 10 });
                Console.WriteLine($"Result of Multiply(5, 10): {result}");
            }
            else
            {
                Console.WriteLine("Method not found.");
            }
        }
    }
}
