using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Flip_key
{
    internal class FlipKey
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the word: ");
            string input = Console.ReadLine();

            FlipKey key = new FlipKey();

            string output = key.CleanseAndInvert(input);

            if (string.IsNullOrEmpty(output))
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                Console.WriteLine("The generated key is - " + output);
            }

        }

        public string CleanseAndInvert(string input)
        {
            // Null check and length check (minimum 6)
            if (string.IsNullOrEmpty(input) || input.Length < 6)
            {
                return "";
            }

            //Check for spaces, digits, or special characters
            if (!Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                return "";
            }

            // Password Generation Logic:
            // Convert to lowercase
            string processed = input.ToLower();

            // Remove characters whose ASCII values are even numbers
            
            StringBuilder oddAsciiOnly = new StringBuilder();
            foreach (char c in processed)
            {
                if ((int)c % 2 != 0)
                {
                    oddAsciiOnly.Append(c);
                }
            }

            //Reverse the remaining characters
            char[] charArray = oddAsciiOnly.ToString().ToCharArray();
            Array.Reverse(charArray);

            // Even positioned characters (0-based index) to uppercase
            StringBuilder finalKey = new StringBuilder();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    finalKey.Append(char.ToUpper(charArray[i]));
                }
                else
                {
                    finalKey.Append(charArray[i]);
                }
            }

            return finalKey.ToString();
        }
    }
}
