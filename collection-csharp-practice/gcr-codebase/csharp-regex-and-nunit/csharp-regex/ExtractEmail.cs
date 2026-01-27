//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Text.RegularExpressions;

//namespace BridgeLabzTraining.csharp_Regex
//{
//    internal class ExtractEmail
//    {
//        public static void Main(string[] args)
//        {
//            string text = "Please contact us at support@gmail.com and info@company.org";
//            string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

//            MatchCollection matches = Regex.Matches(text, pattern);

//            foreach (Match match in matches)
//            {
//                Console.WriteLine("Found email: " + match.Value);
//                Console.WriteLine("Index: " + match.Index);
//            }   
//        }
//    }
//}
