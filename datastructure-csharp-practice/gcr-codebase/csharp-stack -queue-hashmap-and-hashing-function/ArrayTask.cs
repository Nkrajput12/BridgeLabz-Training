using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    public class ArrayTasks
    {
        // Renamed method to be more direct
        public static bool SearchForSum(int[] arr, int k)
        {
            // 'seen' is a very common name students use for HashMaps/Dictionaries
            Dictionary<int, int> seen = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int val = arr[i];
                int diff = k - val; // The value we are looking for

                // If we found the difference in our dictionary, we are done
                if (seen.ContainsKey(diff))
                {
                    Console.WriteLine("Match found: " + diff + " and " + val);
                    return true;
                }

                // Add current number to dictionary if it's not already there
                // We store the value as key and its index as the value
                if (!seen.ContainsKey(val))
                {
                    seen.Add(val, i);
                }
            }

            Console.WriteLine("No pair adds up to " + k);
            return false;
        }

        public static void Main(string[] args)
        {
            int[] data = { 2, 7, 11, 15, 5, 3 };
            int target = 8;

            Console.WriteLine("Searching for sum: " + target);
            SearchForSum(data, target);
        }
    }
}
