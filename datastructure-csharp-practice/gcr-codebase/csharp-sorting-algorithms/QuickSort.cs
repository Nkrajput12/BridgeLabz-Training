using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{

    class QuickSort
    {
        static void Main(string[]args)
        {
            // Sample product prices
            double[] productPrices = { 1200.50, 450.00, 89.99, 1500.00, 320.75, 99.99 };

            Console.WriteLine("Original Prices Before Sorting");
            foreach (double price in productPrices)
            {
                Console.WriteLine(price);
            }

            Quicksort(productPrices, 0, productPrices.Length - 1);

            Console.WriteLine("Prices after  Sorting");
            foreach (double price in productPrices)
            {
                Console.WriteLine(price);

            }

            static void Quicksort(double[] array, int low, int high)
            {
                if (low < high)
                {
                    // pi is the partitioning index, array[pi] is now at right place
                    int pi = Partition(array, low, high);

                    // Recursively sort elements before and after partition
                    Quicksort(array, low, pi - 1);
                    Quicksort(array, pi + 1, high);
                }
            }

            static int Partition(double[] array, int low, int high)
            {
                // Choosing the last element as the pivot
                double pivot = array[high];
                int i = (low - 1); // Index of smaller element

                for (int j = low; j < high; j++)
                {
                    // If current element is smaller than the pivot
                    if (array[j] < pivot)
                    {
                        i++;
                        // Swap array[i] and array[j]
                        double temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }

                // Swap the pivot element with the element at i + 1
                double tempPivot = array[i + 1];
                array[i + 1] = array[high];
                array[high] = tempPivot;

                return i + 1;
            }
        }
    }
}
