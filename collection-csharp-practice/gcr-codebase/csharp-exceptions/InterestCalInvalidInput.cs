using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_exception
{
    internal class InterestCalInvalidInput
    {
        public static void Main(string[] args)
        {
            try
            {

                double interest = CalculateSimpleInterest();

            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine("InvalidInputException caught: " + ex.Message);
            }


        }

        //method for calculating simple interest
        public static double CalculateSimpleInterest()
        {
            Console.Write("Enter Principal: ");
            double principal = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Rate : ");
            double rate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Time: ");
            double time = Convert.ToDouble(Console.ReadLine());

            if (principal < 0 || rate < 0 || time < 0)
            {
                throw new InvalidInputException("Principal, rate, and time must be non-negative.");
            }
            return (principal * rate * time) / 100;
        }
    }
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}
