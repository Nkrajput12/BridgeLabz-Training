using System;
using System.Collections.Generic;

namespace BridgeLabzTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is our starting dictionary (Map)
            Dictionary<string, int> inputMap = new Dictionary<string, int>();

            Console.WriteLine("Enter data (Format: Name Number). Type 'done' to stop.");

            // Loop to take input from the user
            while (true)
            {
                Console.Write("Enter pair: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "done") break;

                // Split the input into parts (e.g., "A 1" becomes ["A", "1"])
                string[] parts = input.Split(' ');

                if (parts.Length == 2)
                {
                    string key = parts[0];
                    if (int.TryParse(parts[1], out int value))
                    {
                        // Add or update the key in the dictionary
                        inputMap[key] = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter both a name and a number.");
                }
            }

            // Now we Invert the Map (The logic from before)
            Dictionary<int, List<string>> invertedMap = new Dictionary<int, List<string>>();

            foreach (var pair in inputMap)
            {
                if (!invertedMap.ContainsKey(pair.Value))
                {
                    invertedMap[pair.Value] = new List<string>();
                }
                invertedMap[pair.Value].Add(pair.Key);
            }

            // Print the inverted results
            Console.WriteLine("\n--- Inverted Map ---");
            foreach (var pair in invertedMap)
            {
                Console.WriteLine(pair.Key + " = [" + string.Join(", ", pair.Value) + "]");
            }
        }
    }
}