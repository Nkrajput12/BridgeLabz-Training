using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class ExtractCurrencyValue
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter text containing currency values:");
            string input = Console.ReadLine();
            string pattern = @"\$\d+(\.\d{2})?";
            var matches = Regex.Matches(input, pattern);
            Console.WriteLine("Extracted currency values:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
