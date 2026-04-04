using System;
class Array2Dto1D
{
    public static void Main(string[] args)
    {   // take rows and columns input from user
        Console.WriteLine("Enter number of rows");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter number of columns");
        int cols = Convert.ToInt32(Console.ReadLine());

        // initialize 2D array
        int[,] array2D = new int[rows, cols];
        // take input for 2D array
        Console.WriteLine("Enter elements of the 2D array");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array2D[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        //size of 1D array
        int size = rows * cols;

        // initialize 1D array
        int[] array1D = new int[size];

        // 2d to 1d conversion
        for (int i = 0, k = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array1D[k] = array2D[i, j];
                k++;
            }
        }

        // print 1D array
        Console.WriteLine("1D array");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine(array1D[i]);
        }


    }
}