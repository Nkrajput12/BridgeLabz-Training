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
                Console.WriteLine("1. Add | 2. Edit | 3. Delete | 4. Display | 5. Back");
                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                switch (choice)
                {
                    case 1: utility.AddContact(); break;
                    case 2: utility.EditContact(); break;
                    case 3: utility.DeleteContact(); break;
                    case 4: utility.Display(); break;
                    case 5: back = true; break;
                }
            }
        }
    }
}