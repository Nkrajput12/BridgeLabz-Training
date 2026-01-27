using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class ExtractCapital
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter text to extract capital letters:");
            string input = Console.ReadLine();

            string pattern = @"[A-Z][a-z]*";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine("Found capital letter: " + match.Value);
            }
        }
    }
}
