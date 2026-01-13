using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_linear_and_binary_search
{
    class PeakElement
    {
        public static void Main(string[] args)
        {
            
            int[] nums = { 1, 2, 3, 1, 4, 6, 5 };

            int peakIndex = FindPeakElement(nums);

            Console.WriteLine($"A peak element is found at index: {peakIndex}");
            Console.WriteLine($"The peak element value is: {nums[peakIndex]}");
        }

        public static int FindPeakElement(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                // Compare mid with the next element
                if (arr[mid] < arr[mid + 1])
                {
                    
                    low = mid + 1;
                }
                else
                {
                    
                    high = mid;
                }
            }

            t
            return low;
        }
    }
}
