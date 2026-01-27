using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class ExtractDates
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter text to extract dates:");
            string input = Console.ReadLine();
            string pattern = @"\b\d{2}/\d{2}/\d{4}\b";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine("Found date: " + match.Value);
            }
        }
    }
}
