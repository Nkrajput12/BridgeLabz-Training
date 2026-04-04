using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    public class SlidingWindow
    {
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) return new int[0];

            int n = nums.Length;
            int[] result = new int[n - k + 1];
            LinkedList<int> list = new LinkedList<int>(); // Stores indices

            for (int i = 0; i < n; i++)
            {
                // Remove indices that are out of the current window bound
                if (list.Count > 0 && list.First.Value <= i - k)
                {
                    list.RemoveFirst();
                }

                // Remove indices of elements smaller than the current element
                
                while (list.Count > 0 && nums[list.Last.Value] <= nums[i])
                {
                    list.RemoveLast();
                }

                // Add current element's index
                list.AddLast(i);

                // The front of the list is the largest element for the window
                if (i >= k - 1)
                {
                    result[i - k + 1] = nums[list.First.Value];
                }
            }

            return result;
        }

        public static void Main()
        {
            int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k = 3;
            int[] result = MaxSlidingWindow(nums, k);

            Console.WriteLine($"Window Size: {k}");
            Console.WriteLine("Input:  " + string.Join(", ", nums));
            Console.WriteLine("Output: " + string.Join(", ", result));
        }
    }
}
