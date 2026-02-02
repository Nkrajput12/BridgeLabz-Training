using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AddressBookSystem
{
    internal class AddressBookMenu
    {
        public static Dictionary<string, List<Contacts>> cityMap = new Dictionary<string, List<Contacts>>();
        public static Dictionary<string, List<Contacts>> stateMap = new Dictionary<string, List<Contacts>>();

        private Dictionary<string, AddressBookUtility> addressBook = new Dictionary<string, AddressBookUtility>();

        public static void MapPersonToLocation(Contacts person)
        {
            // Map City
            if (!cityMap.ContainsKey(person.City)) cityMap[person.City] = new List<Contacts>();
            cityMap[person.City].Add(person);

            // Map State
            if (!stateMap.ContainsKey(person.State)) stateMap[person.State] = new List<Contacts>();
            stateMap[person.State].Add(person);
        }
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n===== ADDRESS BOOK SYSTEM =====");
                Console.WriteLine("1. Add New Address Book");
                Console.WriteLine("2. Open Existing Address Book");
                Console.WriteLine("3. Global Search by City/State");
                Console.WriteLine("4. Get Count by city/state");
                Console.WriteLine("5. Exit");
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
                    ViewByLocation();
                }
                else if(choice == 4)
                {
                    GetCountByLocation();
                }
                else if (choice == 5)
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
        //---------------(This method is use to count the number of contact at location)-------------------
        private void GetCountByLocation()
        {
            Console.WriteLine("\n--- Count Persons by Location ---");
            Console.WriteLine("1. Count by City | 2. Count by State");
            string choice = Console.ReadLine();

            Console.Write("Enter Location Name: ");
            string locationName = Console.ReadLine();

            // Select the appropriate map based on user choice
            var targetMap = (choice == "1") ? cityMap : stateMap;

            if (targetMap.ContainsKey(locationName))
            {
                // UC 10: Using the Count property of the Collection List
                int count = targetMap[locationName].Count;
                Console.WriteLine($"\nTotal number of persons in '{locationName}': {count}");
            }
            else
            {
                Console.WriteLine($"\nTotal number of persons in '{locationName}': 0");
            }
        }
        private void ViewByLocation()
        {
            Console.WriteLine("1. City | 2. State");
            string type = Console.ReadLine();
            Console.Write("Enter Location Name: ");
            string loc = Console.ReadLine();

            var map = (type == "1") ? cityMap : stateMap;

            if (map.ContainsKey(loc))
            {
                foreach (var p in map[loc]) Console.WriteLine($"- {p.FirstName} {p.LastName}");
            }
            else Console.WriteLine("No one found here.");
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
                Console.WriteLine("Press 4 to display all Contact");
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