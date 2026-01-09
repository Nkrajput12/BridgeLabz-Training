using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    public class SumProblem
    {
        // Method to find the two indices
        public static int[] GetIndices(int[] numbers, int targetValue)
        {
            // Dictionary to store the number as the key and its index as the value
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int current = numbers[i];
                int needed = targetValue - current;

                // Check if the number we need to hit the target is already in our map
                if (map.ContainsKey(needed))
                {
                    // If found, return the index of the needed number and the current index
                    return new int[] { map[needed], i };
                }

                // If not found, add the current number and its index to the map
                // We check ContainsKey first to avoid errors with duplicate numbers in the array
                if (!map.ContainsKey(current))
                {
                    map.Add(current, i);
                }
            }

            // Return an empty array or null if no solution is found
            return new int[0];
        }

        public static void Main(string[] args)
        {
            int[] testArray = { 2, 11, 7, 15 };
            int goal = 9;

            int[] result = GetIndices(testArray, goal);

            if (result.Length == 2)
            {
                Console.WriteLine("Indices found: " + result[0] + ", " + result[1]);
                Console.WriteLine("Values: " + testArray[result[0]] + " + " + testArray[result[1]] + " = " + goal);
            }
            else
            {
                Console.WriteLine("No pair found that adds up to the goal.");
            }
        }
    }
}
