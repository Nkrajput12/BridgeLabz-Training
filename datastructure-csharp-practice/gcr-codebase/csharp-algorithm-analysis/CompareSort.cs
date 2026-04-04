using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    class CompareSorts
    {
        // Bubble Sort - Inefficient for large datasets
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap elements
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // Merge Sort
        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);

                Merge(arr, left, mid, right);
            }
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = mid + 1, k = 0;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                    temp[k++] = arr[i++];
                else
                    temp[k++] = arr[j++];
            }

            while (i <= mid)
                temp[k++] = arr[i++];

            while (j <= right)
                temp[k++] = arr[j++];

            for (int m = 0; m < temp.Length; m++)
                arr[left + m] = temp[m];
        }

        // Quick Sort
        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);

                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int swap = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = swap;

            return i + 1;
        }

        static void Main()
        {
            //Generate a dataset of 20,000 random numbers
            int size = 20000;
            int[] originalData = new int[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++) originalData[i] = rand.Next(1, 100000);

            Console.WriteLine($"Comparison for Dataset Size: {size}\n");

            // --- Bubble Sort ---
            int[] bubbleData = (int[])originalData.Clone();
            Stopwatch sw = Stopwatch.StartNew();
            BubbleSort(bubbleData);
            sw.Stop();
            Console.WriteLine($"Bubble Sort (O(N²)):   {sw.ElapsedMilliseconds} ms");

            // --- Merge Sort ---
            int[] mergeData = (int[])originalData.Clone();
            sw.Restart();
            MergeSort(mergeData, 0, mergeData.Length - 1);
            sw.Stop();
            Console.WriteLine($"Merge Sort (O(N log N)): {sw.ElapsedMilliseconds} ms");

            // --- Quick Sort ---
            int[] quickData = (int[])originalData.Clone();
            sw.Restart();
            QuickSort(quickData, 0, quickData.Length - 1);
            sw.Stop();
            Console.WriteLine($"Quick Sort (O(N log N)): {sw.ElapsedMilliseconds} ms");
        }
    }
}
