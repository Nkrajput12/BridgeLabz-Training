using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    internal class ConcatenateStringArray
    {
        public static void Main(string[] args)
        {
            string[] arr = { "Hello", "How", "are", "You" };

            StringBuilder sb = new StringBuilder();

            foreach (string word in arr)
            {
                sb.Append(word).Append(" ");
            }

            string result = sb.ToString();

            Console.WriteLine(result);

        }
    }
}
