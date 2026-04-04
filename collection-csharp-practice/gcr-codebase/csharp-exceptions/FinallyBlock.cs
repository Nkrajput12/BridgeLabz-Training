using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_exception
{
    internal class HandleDivisonError
    {
        public static void Main(string[] args)
        {
            try
            {   //taking input from user
                Console.WriteLine("Enter numerator:");
                int numerator = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter denominator:");
                int denominator = Convert.ToInt32(Console.ReadLine());

                // Performing division
                int result = numerator / denominator;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException ex) //division by zero exception handling
            {
                Console.WriteLine("Error: Division by zero is not allowed. " + ex.Message);
            }
            catch (FormatException ex) //format exception handling
            {
                Console.WriteLine("Error: Invalid input format. Please enter numeric values. " + ex.Message);
            }
            catch (Exception ex) //general exception handling
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Execution of the division operation has completed.");
            }
        }
    }
}
