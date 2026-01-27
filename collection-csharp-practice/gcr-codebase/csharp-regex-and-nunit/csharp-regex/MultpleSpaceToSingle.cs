using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class MultpleSpaceToSingle
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter text with multiple spaces:");
            string input = Console.ReadLine();
            string pattern = @"\s+";
            string replacement = " ";
            string result = Regex.Replace(input, pattern, replacement);
            Console.WriteLine("Text after replacing multiple spaces with single space:");
            Console.WriteLine(result);
        }
    }
}
