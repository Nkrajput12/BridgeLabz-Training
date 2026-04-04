using System;
using System.Collections.Generic;

namespace BridgeLabzTraining
{
    class BankingSystem
    {
        static void Main(string[] args)
        {
            // Storage
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            Queue<(int Id, double Amount)> withdrawalQueue = new Queue<(int, double)>();

            while (true)
            {
                Console.WriteLine("\n--- BANKING MENU ---");
                Console.WriteLine("1. Open Account");
                Console.WriteLine("2. Request Withdrawal (Add to Queue)");
                Console.WriteLine("3. Process Next Withdrawal");
                Console.WriteLine("4. View Balance Leaderboard");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter new Account ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Initial Deposit: ");
                    double deposit = double.Parse(Console.ReadLine());

                    accounts[id] = deposit;
                    Console.WriteLine("Account created!");
                }
                else if (choice == "2")
                {
                    Console.Write("Enter Account ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Amount to Withdraw: ");
                    double amount = double.Parse(Console.ReadLine());

                    withdrawalQueue.Enqueue((id, amount));
                    Console.WriteLine("Request added to queue.");
                }
                else if (choice == "3")
                {
                    if (withdrawalQueue.Count > 0)
                    {
                        var request = withdrawalQueue.Dequeue();
                        if (accounts.ContainsKey(request.Id))
                        {
                            if (accounts[request.Id] >= request.Amount)
                            {
                                accounts[request.Id] -= request.Amount;
                                Console.WriteLine($"Processed! {request.Id} withdrew {request.Amount}.");
                            }
                            else { Console.WriteLine("Insufficient funds!"); }
                        }
                        else { Console.WriteLine("Account not found."); }
                    }
                    else { Console.WriteLine("No requests in queue."); }
                }
                else if (choice == "4")
                {
                    // Using SortedDictionary to display by balance
                    var sorted = new SortedDictionary<double, int>();
                    foreach (var pair in accounts)
                    {
                        // Note: If two accounts have the same balance, 
                        // this simple logic will only show one of them.
                        sorted[pair.Value] = pair.Key;
                    }

                    Console.WriteLine("\nLeaderboard (Low to High):");
                    foreach (var pair in sorted)
                    {
                        Console.WriteLine($"Balance: ${pair.Key} | ID: {pair.Value}");
                    }
                }
                else if (choice == "5") { break; }
            }
        }
    }
}