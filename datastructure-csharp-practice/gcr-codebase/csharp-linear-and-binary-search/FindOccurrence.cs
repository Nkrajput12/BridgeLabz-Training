using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_linear_and_binary_search
{
    class OccurrenceFinder
    {
        public static void Main(string[] args)
        {
            int[] nums = { 1, 2, 4, 4, 4, 4, 5, 8 };
            int target = 4;

            int first = FindOccurrence(nums, target, true);
            int last = FindOccurrence(nums, target, false);

            if (first != -1)
            {
                Console.WriteLine($"Target {target} found!");
                Console.WriteLine($"First Occurrence index: {first}");
                Console.WriteLine($"Last Occurrence index: {last}");
            }
            else
            {
                Console.WriteLine("Target not found in the array.");
            }
        }

        public static int FindOccurrence(int[] arr, int target, bool isFirst)
        {
            int low = 0;
            int high = arr.Length - 1;
            int result = -1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (arr[mid] == target)
                {
                    result = mid; // Potential answer found

                    if (isFirst)
                        high = mid - 1; // Keep looking left
                    else
                        low = mid + 1;  // Keep looking right
                }
                else if (arr[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return result;
        }
    }
}
