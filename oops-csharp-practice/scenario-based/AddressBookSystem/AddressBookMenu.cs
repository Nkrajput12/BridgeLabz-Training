using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AddressBookSystem
{
    internal class AddressBookMenu
    {
        AddressBookUtility utility = new AddressBookUtility();

        public void Run()
        {
            bool exit = false;
            while (!exit)
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
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }
}