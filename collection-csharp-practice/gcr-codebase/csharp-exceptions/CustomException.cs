using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_exception
{
    internal class CustomException
    {
        public static void Main(string[] args)
        {
            try
            {
                // Prompt user for age input
                Console.WriteLine("Enter your age:");
                int age = Convert.ToInt32(Console.ReadLine());

                // Check if age is negative and throw custom exception if so
                if (age < 0)
                {
                    throw new InvalidAgeException("Age cannot be negative.");
                }
            }
            catch (InvalidAgeException ex) // Catching the custom exception
            {
                Console.WriteLine("Custom Exception Caught: " + ex.Message);
            }
            catch (Exception ex)    // Catching any other general exceptions
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }

    // Custom exception class for invalid age
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message)
        {
        }
    }
}
