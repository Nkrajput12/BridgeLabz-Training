using System;
using System.Collections.Generic;

namespace BridgeLabzTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence:");
            string input = Console.ReadLine();

            // Split the sentence into individual words
            // We use ToLower 
            string[] words = input.ToLower().Split(' ');

            // Create the dictionary to store our counts
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                // Clean the word (remove commas or periods)
                string cleanWord = word.Trim(',', '.', '!', '?');

                // Skip empty strings (in case of extra spaces)
                if (string.IsNullOrWhiteSpace(cleanWord)) continue;

                //Check if the word is already in our dictionary
                if (counts.ContainsKey(cleanWord))
                {
                    // If it exists, add 1 to the current count
                    counts[cleanWord]++;
                }
                else
                {
                    // If it's new, add it to the dictionary with a count of 1
                    counts[cleanWord] = 1;
                }
            }

            // 4. Print the results
            Console.WriteLine("\nWord Frequencies:");
            foreach (var pair in counts)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }
        }
    }
}