using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_exception
{
    internal class NestedTryCatch
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Outer Try Block");
                try
                {
                    Console.WriteLine("Inner Try Block");
                    Console.WriteLine("Enter numerator:");
                    int numerator = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter denominator:");
                    int denominator = Convert.ToInt32(Console.ReadLine());
                    int result = numerator / denominator;
                    Console.WriteLine("Result: " + result);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Inner Catch: Invalid input format. Please enter numeric values. " + ex.Message);
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Outer Catch: Division by zero is not allowed. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Outer Catch: An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
