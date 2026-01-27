using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class HexCode
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Hexadecimal color code:");
            string input = Console.ReadLine();
            string pattern = @"^#[0-9A-Fa-f]{6}$";

            if (Regex.IsMatch(input, pattern))
            {
                Console.WriteLine("Valid Hexadecimal color code");
            }
            else
            {
                Console.WriteLine("Invalid Hexadecimal color code");
            }

        }
    }
}
