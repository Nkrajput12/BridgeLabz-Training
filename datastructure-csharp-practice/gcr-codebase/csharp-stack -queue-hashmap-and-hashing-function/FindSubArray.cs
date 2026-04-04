using System;
using System.Collections.Generic;

namespace SubArray
{
    public class SubarrayLogic
    {
        // Renamed method to be more descriptive but less "textbook"
        public static void CheckForZeroSum(int[] data)
        {
            int size = data.Length;
            int s = 0; // Using 's' for current running sum

            // Renamed dictionary to something more generic
            var tracker = new Dictionary<int, List<int>>();

            // Handling the base case: sum of 0 at an imaginary index -1
            tracker.Add(0, new List<int> { -1 });

            Console.WriteLine("Array elements: " + string.Join(", ", data));
            bool isFound = false;

            for (int i = 0; i < size; i++)
            {
                s += data[i];

                // If this sum has been seen before, we found a zero-sum range
                if (tracker.ContainsKey(s))
                {
                    List<int> oldIndices = tracker[s];
                    foreach (int startIdx in oldIndices)
                    {
                        // The subarray starts right after the previous time we saw this sum
                        Console.WriteLine($"Found zero-sum from index {startIdx + 1} to {i}");
                        isFound = true;
                    }
                }

                // Store the current index for this sum
                if (!tracker.ContainsKey(s))
                {
                    tracker[s] = new List<int>();
                }
                tracker[s].Add(i);
            }

            if (!isFound)
            {
                Console.WriteLine("No results found.");
            }
        }

        public static void Main(string[] args)
        {
            int[] inputArr = { 6, 3, -1, -3, 4, -2, 2, 4, 6, -12, -7 };
            CheckForZeroSum(inputArr);
        }
    }
}