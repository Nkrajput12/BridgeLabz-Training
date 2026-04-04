using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class LicensePlate
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter lincense plate number");
            string input = Console.ReadLine();

            string pattern = @"^[A-B]{2}\d{4}$";

            if (Regex.IsMatch(input, pattern))
            {
                Console.WriteLine("valid License Plate number");
            }
            else
            {
                Console.WriteLine("Invalid License Plate number");
            }
        }
    }
}
