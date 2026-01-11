using System;

class InsertionSort
{
    static void Main(string[]args)
    {
        // Sample Employee IDs
        int[] employeeIds = { 105, 101, 110, 103, 108, 102 };

        Console.WriteLine("Ids before sorting");
        foreach (int employeeId in employeeIds)
        {
            Console.WriteLine(employeeId);
        }

        InsertionSorting(employeeIds);

        Console.WriteLine("Ids after sorting");
        foreach(int employeeId in employeeIds)
        {
            Console.WriteLine(employeeId);
        }
    }

    static void InsertionSorting(int[] array)
    {
        int n = array.Length;

        // Start from the second element (index 1)
        for (int i = 1; i < n; i++)
        {
            int key = array[i]; // The ID we want to insert
            int j = i - 1;

            
            // to one position ahead of their current position
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }

            // Place the key into its correct spot
            array[j + 1] = key;
        }
    }
}