using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_linear_and_binary_search
{
    internal class _2DSortdMatrix
    {
        public static void Main(string[] args)
        {


            int[,] matrix = {
                { 1,  3,  5,  7 },
                { 10, 11, 16, 20 },
                { 23, 30, 34, 60 }
            };

            int target = 3;
            bool found = SearchMatrix(matrix, target);
            if (found)
            {
                Console.WriteLine("found");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        public static bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0) return false;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int low = 0;
            int high = (rows * cols) - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                
                int midRow = mid / cols;
                int midCol = mid % cols;
                int midValue = matrix[midRow, midCol];

                if (midValue == target)
                {
                    Console.WriteLine($"Found at Row: {midRow}, Col: {midCol}");
                    return true;
                }
                else if (midValue < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return false;
        }

    }

   
    }
