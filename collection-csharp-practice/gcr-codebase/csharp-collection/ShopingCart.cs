using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized; // Needed for OrderedDictionary

namespace BridgeLabzTraining
{
    class ShopingCart
    {
        static void Main(string[] args)
        {
            // 1. Setup the shop prices
            Dictionary<string, double> shopStock = new Dictionary<string, double>()
            {
                { "apple", 0.50 },
                { "bread", 1.50 },
                { "milk", 2.00 },
                { "eggs", 3.00 }
            };

            // 2. The Cart (Remembers the order you picked items)
            OrderedDictionary myCart = new OrderedDictionary();

            Console.WriteLine("Welcome! Available items: apple, bread, milk, eggs");

            while (true)
            {
                Console.WriteLine("\nMenu: [1] Add Item  [2] View Receipt  [3] View by Price  [4] Exit");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("What would you like to buy? ");
                    string item = Console.ReadLine().ToLower();

                    if (shopStock.ContainsKey(item))
                    {
                        // Add to OrderedDictionary
                        myCart[item] = shopStock[item];
                        Console.WriteLine("Added " + item + " to cart.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, we don't sell that.");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\n--- YOUR RECEIPT (Order Added) ---");
                    foreach (DictionaryEntry entry in myCart)
                    {
                        Console.WriteLine(entry.Key + ": $" + entry.Value);
                    }
                }
                else if (choice == "3")
                {

                    SortedDictionary<double, string> priceSorted = new SortedDictionary<double, string>();

                    foreach (DictionaryEntry entry in myCart)
                    {
                        double price = (double)entry.Value;
                        string name = (string)entry.Key;
                        priceSorted[price] = name;
                    }

                    Console.WriteLine("\n--- ITEMS BY PRICE (Low to High) ---");
                    foreach (var pair in priceSorted)
                    {
                        Console.WriteLine("$" + pair.Key + " - " + pair.Value);
                    }
                }
                else if (choice == "4")
                {
                    break;
                }
            }
        }
    }
}