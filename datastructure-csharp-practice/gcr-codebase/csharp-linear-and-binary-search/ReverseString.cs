
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    internal class ReverseString
    {
        public static void Main(string[] args)
        {
            ReverseString r = new ReverseString();

            Console.Write("Enter String: ");
            string str = Console.ReadLine();
            string rev = r.Reverse(str);

            Console.WriteLine("String after reverse is : \"" + rev + "\"");
        }

        //method to reverse the string
        public string Reverse(string str)
        {
            StringBuilder rev = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                rev.Append(str[i]);
            }

            return rev.ToString();
        }
    }
}
