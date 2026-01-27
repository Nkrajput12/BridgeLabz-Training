using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.csharp_Regex
{
    internal class ValidCreditCard
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Credit Card Number to validate:");
            string number = Console.ReadLine();

            string pattern = @"(^4[0-9]{15}|(^5[0-9]{15}))";

            if (Regex.IsMatch(number, pattern))
            {
                Console.WriteLine("Valid Card number");
            }
            else
            {
                Console.WriteLine("Invalid Card Number");
            }
        }
    }
}
