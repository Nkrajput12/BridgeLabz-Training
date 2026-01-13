using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    class RotatedArray
    {
        public static void Main(string[] args)
        {
            // Example of  rotated array            
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };

            int min = FindRotationPoint(nums);

            if (min != -1)
            {
                Console.WriteLine($"The array is rotated at index: {min}");
                Console.WriteLine($"The smallest element is: {nums[min]}");
            }
            else
            {
                Console.WriteLine("Array is empty.");
            }
        }

        public static int FindRotationPoint(int[] arr)
        {
            if (arr == null || arr.Length == 0) return -1;

            int low = 0;
            int high = arr.Length - 1;

            // Loop until low and high meet
            while (low < high)
            {
                int mid = low + (high - low) / 2;

                // The middle element is greater than the rightmost element.
                if (arr[mid] > arr[high])
                {
                    low = mid + 1;
                }
                // The middle element is less than or equal to the rightmost. 
                else
                {
                    high = mid;
                }
            }

            // When low == high
            return low;
        }
    }
}
