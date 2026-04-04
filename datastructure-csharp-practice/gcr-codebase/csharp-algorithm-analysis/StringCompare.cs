using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    class StringCompare
    {
        static void Main()
        {
            int n = 100000; 
            Console.WriteLine($"Concatenating {n} strings:\n");

            // --- StringBuilder Approach ---
            Stopwatch sw = Stopwatch.StartNew();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append("a");
            }
            string resultSb = sb.ToString();
            sw.Stop();
            Console.WriteLine($"StringBuilder (O(N)): {sw.ElapsedMilliseconds} ms");

            // --- String (Immutable) Approach ---
            // Warning: Do not run this with 1,000,000 iterations!
            sw.Restart();
            string s = "";
            for (int i = 0; i < n; i++)
            {
                s += "a";

            }
            sw.Stop();
            Console.WriteLine($"String += (O(N²)):    {sw.Elapsed.TotalMilliseconds} ms");
        }
    }
}
