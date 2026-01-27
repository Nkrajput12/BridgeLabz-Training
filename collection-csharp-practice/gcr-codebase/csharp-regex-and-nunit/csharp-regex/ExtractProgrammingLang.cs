using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class ExtractProgrammingLang
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter text containing programming languages:");
            string input = Console.ReadLine();

            string pattern = @"\b(c\#|Java|Python|JavaScript|C|C\+\+|f\#)\b";
            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

            Console.WriteLine("Found programming language: ");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
