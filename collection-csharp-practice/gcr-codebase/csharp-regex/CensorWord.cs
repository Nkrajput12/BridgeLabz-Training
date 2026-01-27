using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class CensorWord
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter text:");
            string input = Console.ReadLine();
            Console.WriteLine("Enter word to censor");

            string[] wordToCensor = Console.ReadLine().Split(',').Select(w => w.Trim()).ToArray();

            string joinedWords = string.Join("|", wordToCensor);

            string pattern = $@"\b({joinedWords})\b";
            string replacement = "****";
            string result = Regex.Replace(input, pattern, replacement, RegexOptions.IgnoreCase);

            Console.WriteLine("Text after censoring specified words:");
            Console.WriteLine(result);

        }
    }
}
