using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class RepeatingWords
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence to check for repeating words:");
            string input = Console.ReadLine();
            string pattern = @"\b(\w+)\s+\1\b";

            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

            if (matches.Count > 0)
            {
                Console.WriteLine("Repeating words found:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("No repeating words found.");
            }

        }
    }
}
