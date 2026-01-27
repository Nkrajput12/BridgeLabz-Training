using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class ValidateSSN
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter SSN to validate (format: XXX-XX-XXXX):");
            string ssn = Console.ReadLine();

            string pattern = @"^(?!000|666|9\d{2})\d{3}-(?!00)\d{2}-(?!0000)\d{4}$";

            if(Regex.IsMatch(ssn, pattern))
            {
                Console.WriteLine("Valid SSN");
            }
            else
            {
                Console.WriteLine("Invalid SSN");
            }
        }
    }
}
