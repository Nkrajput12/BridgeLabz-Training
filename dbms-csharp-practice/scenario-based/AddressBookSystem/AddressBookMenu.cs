using System;

namespace BridgeLabzTraining.AddressBookSystem
{
    internal class AddressBookMenu
    {
        AddressBookManager manager = new AddressBookManager();

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n========== MAIN MENU ==========");
                Console.WriteLine("1. Create New Book");
                Console.WriteLine("2. Open Existing Book");
                Console.WriteLine("3. View Persons by Location (UC 9)");
                Console.WriteLine("4. Get Count by Location (UC 10)");
                Console.WriteLine("5. Exit");
                Console.Write("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Unique Book Name: ");
                        manager.CreateBook(Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("Enter Book Name to Open: ");
                        string name = Console.ReadLine();
                        if (manager.addressBookDict.ContainsKey(name))
                            HandleBook(manager.addressBookDict[name]);
                        else
                            Console.WriteLine("Address Book not found.");
                        break;
                    case 3:
                        manager.ViewByLocation(); 
                        break;
                    case 4:
                        manager.GetCount(); 
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }

        private void HandleBook(AddressBookUtility utility)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- BOOK OPERATIONS ---");
                Console.WriteLine("1. Add | 2. Edit | 3. Delete | 4. Display | 5. Sort(Name)  |6. Sort(Location) |7. SaveToFile");
                Console.WriteLine("8. Load From File | 9. Save to CSV | 10. Load from CSV | 11. Save to json | 12. Read from json | 13. Sync Json Server");
                Console.WriteLine("14. Save data to database  |  15. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: utility.AddContact(); break;
                    case 2: utility.EditContact(); break;
                    case 3: utility.DeleteContact(); break;
                    case 4: utility.Display(); break;
                    case 5: utility.SortByName(); break;
                    case 6: utility.SortByLocation(); break;
                    case 7: utility.WriteToFile(); break;
                    case 8: utility.ReadFromFile(); break;
                    case 9: utility.WriteToCsv(); break;
                    case 10: utility.ReadFromCsv(); break;
                    case 11: utility.WriteToJSONAsync(); break;
                    case 12: utility.ReadFromJSON(); break;
                    case 13: utility.SyncWithJsonServer(); break;
                    case 14: utility.SaveToDb(); break;
                    case 15: back = true; break;
                }
            }
        }
    }
}