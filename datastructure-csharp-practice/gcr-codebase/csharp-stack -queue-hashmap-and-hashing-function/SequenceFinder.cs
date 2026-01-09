using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    
        public class SequenceFinder
        {
            public static int GetLongestSequence(int[] arr)
            {
                if (arr.Length == 0) return 0;

                // Put everything in a HashSet for fast O(1) lookups
                HashSet<int> numsSet = new HashSet<int>();
                foreach (int n in arr)
                {
                    numsSet.Add(n);
                }

                int maxLen = 0;

                // Go through the original array
                foreach (int item in arr)
                {
                    // Check if 'item' is the start of a sequence.
                    // It's a start if 'item - 1' is NOT in the set.
                    if (!numsSet.Contains(item - 1))
                    {
                        int currentNum = item;
                        int currentLen = 1;

                        // Keep looking for the next consecutive numbers
                        while (numsSet.Contains(currentNum + 1))
                        {
                            currentNum++;
                            currentLen++;
                        }

                        // Update the global maximum length
                        if (currentLen > maxLen)
                        {
                            maxLen = currentLen;
                        }
                    }
                }

                return maxLen;
            }

            public static void Main(string[] args)
            {
                int[] myArr = { 100, 4, 200, 1, 3, 2 };

                int result = GetLongestSequence(myArr);

                Console.WriteLine("Array: " + string.Join(", ", myArr));
                Console.WriteLine("Longest consecutive sequence length: " + result);
            }
        }
    
}
