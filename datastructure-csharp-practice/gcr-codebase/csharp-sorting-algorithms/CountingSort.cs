using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    class CountingSort
    {
        static void Main(string[]args)
        {
            // Sample student ages (Range: 10 to 18)
            int[] studentAges = { 12, 10, 15, 12, 18, 11, 15, 10, 14 };

            Console.WriteLine("Original Ages:");
            foreach (int age in studentAges) Console.Write(age + " ");
            

            Countingsort(studentAges, 10, 18);

            Console.WriteLine("Sorted Ages (Ascending):");
            foreach (int age in studentAges) Console.Write(age + " ");
           
        }

        static void Countingsort(int[] array, int min, int max)
        {
            int n = array.Length;
            int range = max - min + 1;

            int[] count = new int[range];
            int[] output = new int[n];

            // Store the count of each element
            for (int i = 0; i < n; i++)
            {
                count[array[i] - min]++;
            }

            // Change count[i] so that it contains the actual 
            // position of this element in the output array 
            for (int i = 1; i < range; i++)
            {
                count[i] += count[i - 1];
            }

            // Build the output array
            // We traverse backwards to maintain stability
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[array[i] - min] - 1] = array[i];
                count[array[i] - min]--;
            }

            //Copy the output array to the original array
            for (int i = 0; i < n; i++)
            {
                array[i] = output[i];
            }
        }
    }
}
