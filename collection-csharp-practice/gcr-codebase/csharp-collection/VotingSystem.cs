using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized; // Required for OrderedDictionary

namespace BridgeLabzTraining
{
    class VotingSystem
    {
        static void Main(string[] args)
        {
            // Dictionary: Fast lookup to update vote counts
            Dictionary<string, int> voteCounts = new Dictionary<string, int>();

            //OrderedDictionary: To remember the order in which votes were cast
            OrderedDictionary voteHistory = new OrderedDictionary();

            Console.WriteLine("Welcome to the Voting System!");
            Console.WriteLine("Enter candidate name to vote. Type 'exit' to see results.");

            int voteId = 1;
            while (true)
            {
                Console.Write($"Vote #{voteId}: ");
                string candidate = Console.ReadLine().Trim();

                if (candidate.ToLower() == "exit") break;

                // Update the count (Dictionary)
                if (voteCounts.ContainsKey(candidate))
                    voteCounts[candidate]++;
                else
                    voteCounts[candidate] = 1;

                // Record the history (OrderedDictionary / LinkedHashMap logic)
                voteHistory.Add(voteId, candidate);

                voteId++;
                Console.WriteLine("Vote recorded!");
            }

            //SortedDictionary: To display results sorted by Candidate Name
            SortedDictionary<string, int> sortedResults = new SortedDictionary<string, int>(voteCounts);

            Console.WriteLine("\n--- VOTING SUMMARY ---");

            Console.WriteLine("\n1. Election Results (Alphabetical Order):");
            foreach (var pair in sortedResults)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} votes");
            }

            Console.WriteLine("\n2. Vote Log (Order they were cast):");
            foreach (DictionaryEntry entry in voteHistory)
            {
                Console.WriteLine($"Ticket #{entry.Key}: Voted for {entry.Value}");
            }
        }
    }
}