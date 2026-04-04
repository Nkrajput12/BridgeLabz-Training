using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    

    class MergeSort
    {
        static void Main()
        {
            // Sample book prices
            double[] bookPrices = { 599.99, 120.50, 450.00, 99.99, 850.75, 210.00 };

            Console.WriteLine("Original Prices before Sorting")
            foreach(double b in bookPrices)
            {
                Console.WriteLine(b);
            }

            MergeSorting(bookPrices, 0, bookPrices.Length - 1);

            Console.WriteLine("Sorted Prices (Ascending): ");
            foreach (double b in bookPrices)
            {
                Console.WriteLine(b);
            }
        }

        static void MergeSorting(double[] array, int left, int right)
        {
            if (left < right)
            {
                // Find the middle point
                int middle = left + (right - left) / 2;

                // Sort first and second halves
                MergeSorting(array, left, middle);
                MergeSorting(array, middle + 1, right);

                // Merge the sorted halves
                Merge(array, left, middle, right);
            }
        }

        static void Merge(double[] array, int left, int middle, int right)
        {
            // Sizes of two subarrays to be merged
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Create temporary arrays
            double[] leftArray = new double[n1];
            double[] rightArray = new double[n2];

            // Copy data to temp arrays
            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, middle + 1, rightArray, 0, n2);

            // Initial indexes of first and second subarrays
            int i = 0, j = 0;

            // Initial index of merged subarray array
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements of leftArray[] if any
            while (i < n1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            // Copy remaining elements of rightArray[] if any
            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}
