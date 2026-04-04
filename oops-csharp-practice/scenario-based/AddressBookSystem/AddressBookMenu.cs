using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AddressBookSystem
{
    internal class AddressBookMenu
    {
        Dictionary<string, AddressBookUtility> addressBook = new Dictionary<string, AddressBookUtility>();
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n===== ADDRESS BOOK SYSTEM =====");
                Console.WriteLine("1. Add New Address Book");
                Console.WriteLine("2. Open Existing Address Book");
                Console.WriteLine("3. Global Search by City/State");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter unique Address book Name");
                    string book = Console.ReadLine();
                    if (!addressBook.ContainsKey(book))
                    {
                        addressBook.Add(book, new AddressBookUtility());
                        Console.WriteLine(book + " added Successfully");

                    }
                    else Console.WriteLine("book already exist");
                }
                else if(choice == 2)
                {
                    Console.WriteLine("Enter a name to open book");
                    string book = Console.ReadLine();
                    if (addressBook.ContainsKey(book))
                    {
                        HandleBook(addressBook[book], book);
                    }
                    else
                    {
                        Console.WriteLine("!!!Book not found!!!");
                    }
                }
                else if(choice == 3)
                {
                    GlobalSearchByLocation();
                }
                else if(choice == 4)
                {
                    exit = true;
                    Console.WriteLine("Exit");
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }


            }
        }

        
        private void GlobalSearchByLocation()
        {
            Console.WriteLine("\n--- Global Search ---");
            Console.WriteLine("Search by: 1. City | 2. State");
            string choice = Console.ReadLine();
            bool isCity = (choice == "1");

            Console.Write($"Enter {(isCity ? "City" : "State")} Name: ");
            string searchTarget = Console.ReadLine();

            bool anyResultsFound = false;

            // Iterate through all Address Books in the Dictionary
            foreach (var entry in addressBook)
            {
                string bookName = entry.Key;
                AddressBookUtility utility = entry.Value;

                // Print header for the book being searched
                Console.WriteLine($"\nLooking in Address Book: {bookName}...");

                // The utility handles the internal array loop
                bool found = utility.SearchAndDisplayByLocation(searchTarget, isCity);

                if (found) anyResultsFound = true;
                else Console.WriteLine("(No matches in this book)");
            }

            if (!anyResultsFound)
            {
                Console.WriteLine($"\nResult: No persons found in '{searchTarget}' across the entire system.");
            }
        }


        public void HandleBook(AddressBookUtility utility,string bookName)
        {
            Console.WriteLine("----------------- " + bookName + " Book Open -------------------");
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Press 1 to Add Contact");
                Console.WriteLine("press 2 to edit Contact");
                Console.WriteLine("Press 3 to delete Contact");
                Console.WriteLine("Press 4 to displat all Contact");
                Console.WriteLine("press 5 to exit");
                Console.Write("Input Here: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.AddContact();
                        break;

                    case 2:
                        utility.EditContact();
                        break;

                    case 3:
                        utility.DeleteContact();
                        break;

                    case 4:
                        utility.Display();
                        break;

                    case 5:
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }
}