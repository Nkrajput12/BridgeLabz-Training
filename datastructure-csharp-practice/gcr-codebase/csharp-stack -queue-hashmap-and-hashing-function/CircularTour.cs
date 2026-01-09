using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    

    public class CircularTour
    {
        public static int FindStartingPoint(int[] petrol, int[] distance)
        {
            int n = petrol.Length;

            int totalplus = 0;   // To check if a solution even exists
            int currentTank = 0;    // Petrol in tank during the current attempt
            int startPoint = 0;     // The pump index we are trying as a start

            for (int i = 0; i < n; i++)
            {
                int netFuel = petrol[i] - distance[i];

                totalplus += netFuel;
                currentTank += netFuel;

                // If currentTank < 0, we cannot start from start point
                if (currentTank < 0)
                {
                    
                    startPoint = i + 1;
                    // Reset our tank for the new start point
                    currentTank = 0;
                }
            }

            // If totalSurplus is negative not possible to finish the circle
            if (totalplus >= 0)
            {
                return startPoint;
            }
            else
            {
                return -1; // No solution
            }
        }

        public static void Main(string[]args)
        {
            // Example: Pump 0: 4L petrol, 6km to next. Pump 1: 6L petrol, 4km to next.
            int[] petrol = { 4, 6, 7, 4 };
            int[] distance = { 6, 5, 3, 5 };

            int result = FindStartingPoint(petrol, distance);

            if (result == -1)
                Console.WriteLine("No circular tour possible.");
            else
                Console.WriteLine("Start at Petrol Pump index: " + result);
        }
    }
}
