using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class ValidateIP
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter an IP address to validate:");
            string input = Console.ReadLine();
            string pattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?$)";

            if (Regex.IsMatch(input, pattern))
            {
                Console.WriteLine("Valid IP address");
            }
            else
            {
                Console.WriteLine("Invalid IP address");
            }
        }
    }
}
