using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
   
    class SelectionSort
    {
        static void Main()
        {
            // Sample exam scores
            int[] examScores = { 72, 45, 98, 82, 61, 89 };

            Console.WriteLine("Original Scores before sorting");
            foreach(int score in examScores)
            {
                Console.WriteLine(score);
            }

            Selectionsort(examScores);

            Console.WriteLine("Scores after sorting");
            foreach (int score in examScores)
            {
                Console.WriteLine(score);
            }
        }

        static void Selectionsort(int[] array)
        {
            int n = array.Length;

            // One by one move the boundary of the unsorted subarray
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in the unsorted array
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Swap the found minimum element with the first element of the unsorted part
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }
    }
}
