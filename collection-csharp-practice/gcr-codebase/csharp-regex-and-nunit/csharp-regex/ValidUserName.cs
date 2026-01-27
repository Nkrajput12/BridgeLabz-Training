using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class ValidUserName
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter User Name:");
            string input = Console.ReadLine();

            string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{4,14}$";

            if (Regex.IsMatch(input, pattern))
            {
                Console.WriteLine("valid UserName");
            }
            else
            {
                Console.WriteLine("Invalid User name");
            }


        }
    }
}
