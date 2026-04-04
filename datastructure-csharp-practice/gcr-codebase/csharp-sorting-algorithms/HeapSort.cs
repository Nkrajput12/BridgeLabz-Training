using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    class HeapSort
    {
        public void Sort(int[] salaries)
        {
            int totalApplicants = salaries.Length;

            //Organize the "pile"
            // We start halfway back because the last half are "leaves" (they don't have children).
            // We're basically making sure the highest salary is sitting at the very top (index 0).
            for (int i = totalApplicants / 2 - 1; i >= 0; i--)
            {
                FixTheHeap(salaries, totalApplicants, i);
            }

            //  The actual sorting
            // We take the biggest salary from the top, swap it to the end of the line, 
            // and then pretend that person isn't in the pile anymore.
            for (int i = totalApplicants - 1; i > 0; i--)
            {
                // Move the "Big Boss" salary to its final spot at the back
                int highestSalary = salaries[0];
                salaries[0] = salaries[i];
                salaries[i] = highestSalary;


                // We need to push the new top value down until the next highest salary is at the root.
                FixTheHeap(salaries, i, 0);
            }
        }

        // This is our helper that ensures the "Parent" salary is always bigger than the "Child" salaries.
        void FixTheHeap(int[] arr, int size, int rootIndex)
        {
            int largest = rootIndex;
            int leftChild = 2 * rootIndex + 1;
            int rightChild = 2 * rootIndex + 2;

            // Check if the left child exists and if their salary is higher than the current 'largest'
            if (leftChild < size && arr[leftChild] > arr[largest])
                largest = leftChild;

            // Check if the right child is actually the one with the highest salary
            if (rightChild < size && arr[rightChild] > arr[largest])
                largest = rightChild;

            // If 'largest' isn't the root anymore, we need to swap them
            if (largest != rootIndex)
            {
                int temp = arr[rootIndex];
                arr[rootIndex] = arr[largest];
                arr[largest] = temp;

                // Since we moved a value down, it might still be smaller than its new kids.
                // We keep "Fixing" recursively until it finds its proper level.
                FixTheHeap(arr, size, largest);
            }
        }

        public static void Main()
        {
            // Example list of what people are asking for
            int[] Salaries = { 55000, 120000, 45000, 75000, 90000, 60000 };

            HeapSort sorter = new HeapSort();
            sorter.Sort(Salaries);

            Console.WriteLine("Salaries sorted from lowest to highest:");
            Console.WriteLine(string.Join(" ,", Salaries));
        }

    }
}
