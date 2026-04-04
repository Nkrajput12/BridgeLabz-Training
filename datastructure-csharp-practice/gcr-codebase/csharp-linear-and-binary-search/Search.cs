using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_linear_and_binary_search
{
    class Search
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 4, -1, 1 };
            int target = 4;

            // Find First Missing Positive (Linear Search Approach)
            int missing = FindFirstMissingPositive(numbers);
            Console.WriteLine($"First missing positive integer: {missing}");

            // Find Target Index (Binary Search Approach)
            // Binary search requires a sorted array
            Array.Sort(numbers);
            Console.WriteLine($"Sorted array for Binary Search: [{string.Join(", ", numbers)}]");

            int targetIndex = BinarySearch(numbers, target);
            Console.WriteLine(targetIndex != -1
                ? $"Target {target} found at sorted index: {targetIndex}"
                : $"Target {target} not found.");
        }

        // --- Linear Search Approach ---
        public static int FindFirstMissingPositive(int[] nums)
        {
            int n = nums.Length;

            // Step A: Move each number to its correct index (e.g., '1' should be at index 0)
            for (int i = 0; i < n; i++)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    // Swap nums[i] with the element at its target position
                    int temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;
                }
            }

            // linear search for the first index that doesn't match its value
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return n + 1;
        }

        // --- Binary Search Approach ---
        public static int BinarySearch(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (arr[mid] == target) return mid;

                if (arr[mid] < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }
    }
}
