using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_annotations_and_reflection.csharp_reflection
{
    public class MathOperations
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
    }

    class Program
    {
        static void Main()
        {
            MathOperations math = new MathOperations();

            Console.WriteLine("Enter Operation (Add, Subtract, Multiply):");
            string methodName = Console.ReadLine(); // User input

            //  Get the method by the name provided by the user
            MethodInfo method = typeof(MathOperations).GetMethod(methodName);

            if (method != null)
            {
                // Prepare parameters
                object[] parameters = { 20, 10 };

                // Invoke it
                object result = method.Invoke(math, parameters);
                Console.WriteLine($"Result of {methodName}: {result}");
            }
            else
            {
                Console.WriteLine("Invalid method name!");
            }
        }
    }
}