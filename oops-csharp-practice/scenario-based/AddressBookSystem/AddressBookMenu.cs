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
                Console.WriteLine("3. Exit");
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
                    exit = true;
                    Console.WriteLine("Exit");
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }


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