using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Library_mangement
{
    internal class LibraryMenu
    {
        BookUtility utility = new BookUtility();

        public void Run()
        {
            Console.WriteLine("-------Welcome to the library Management-----------");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Press 1 to add book");
                Console.WriteLine("Press 2 to search book");
                Console.WriteLine("press 3 to Checkout the book");
                Console.WriteLine("press 4 to display all the book");
                Console.WriteLine("Press 5 to exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        utility.AddBook();
                        break;
                    case 2:
                        utility.Searching();
                        break;
                    case 3:
                        utility.CheckOut();
                        break;
                    case 4:
                        utility.Display();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
