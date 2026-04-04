using System;
using System.Collections.Generic;

namespace BridgeLabzTraining.AddressBookSystem
{
    internal class AddressBookManager
    {
        public Dictionary<string, AddressBookUtility> addressBookDict = new Dictionary<string, AddressBookUtility>();
        public static Dictionary<string, List<Contacts>> cityMap = new Dictionary<string, List<Contacts>>();
        public static Dictionary<string, List<Contacts>> stateMap = new Dictionary<string, List<Contacts>>();

        //method is use to create a book 
        public void CreateBook(string name)
        {
            if (!addressBookDict.ContainsKey(name))
            {
                addressBookDict.Add(name, new AddressBookUtility());
                Console.WriteLine($"Address Book '{name}' created.");
            }
            else Console.WriteLine("Name already exists.");
        }

        public void MapPersonToLocation(Contacts person)
        {
            if (!cityMap.ContainsKey(person.City)) cityMap[person.City] = new List<Contacts>();
            cityMap[person.City].Add(person);

            if (!stateMap.ContainsKey(person.State)) stateMap[person.State] = new List<Contacts>();
            stateMap[person.State].Add(person);
        }

        //UC-9 get contact by location
        public void ViewByLocation()
        {
            Console.WriteLine("\nView by: 1. City | 2. State");
            string choice = Console.ReadLine();
            Console.Write("Enter Name of Location: ");
            string locationName = Console.ReadLine();

            var targetMap = (choice == "1") ? cityMap : stateMap;

            if (targetMap.ContainsKey(locationName))
            {
                Console.WriteLine($"--- Persons in {locationName} ---");
                foreach (var person in targetMap[locationName])
                {
                    Console.WriteLine($"- {person.FirstName} {person.LastName}");
                }
            }
            else Console.WriteLine("No records found for this location.");
        }

        // UC-10 Get Count by City or State
        public void GetCount()
        {
            Console.WriteLine("\nCount by: 1. City | 2. State");
            string choice = Console.ReadLine();
            Console.Write("Enter Name of Location: ");
            string locationName = Console.ReadLine();

            var targetMap = (choice == "1") ? cityMap : stateMap;

            int count = targetMap.ContainsKey(locationName) ? targetMap[locationName].Count : 0;
            Console.WriteLine($"Total number of persons in '{locationName}': {count}");
        }

        
    }
}