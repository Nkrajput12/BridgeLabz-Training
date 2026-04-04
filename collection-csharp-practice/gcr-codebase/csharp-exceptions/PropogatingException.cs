using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_exception
{
    internal class PropogatingException
    {
        public static void Main(string[] args)
        {
            try
            {
                PerformDivision();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error caught in Main: Division by zero is not allowed. " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error caught in Main: Invalid input format. Please enter numeric values. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred in Main: " + ex.Message);
            }
        }
        static void PerformDivision()
        {
            //taking input from user
            Console.WriteLine("Enter numerator:");
            int numerator = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter denominator:");
            int denominator = Convert.ToInt32(Console.ReadLine());
            // Performing division
            double result = Divide(numerator, denominator);
            Console.WriteLine("Result: " + result);
        }


        static double Divide(int numerator, int denominator)
        {
            return numerator / denominator;
        }
    }
}
