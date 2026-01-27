using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class ExtractLinks
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter text to extract links:");
            string input = Console.ReadLine();

            string pattern = @"https?://[a-zA-Z0-9._+-]+\.[a-zA-Z]{2,}";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine("Found link: " + match.Value);
            }

        }
    }
}
