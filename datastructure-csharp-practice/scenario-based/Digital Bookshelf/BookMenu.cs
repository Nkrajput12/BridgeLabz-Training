using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Digital_Bookshelf
{
    public class BookMenu
    {
        private BookUtility utility = new BookUtility();

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n--- BookBuddy Menu ---");
                Console.WriteLine("1. Add Book\n2. View All\n3. Sort\n4. Search Author\n5. Export & Exit");
                Console.Write("Choice: ");

                try
                {
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Title: "); string t = Console.ReadLine();
                            Console.Write("Author: "); string a = Console.ReadLine();
                            utility.AddBook(t, a);
                            break;
                        case "2": utility.DisplayAll(); break;
                        case "3": utility.SortBooks(); break;
                        case "4":
                            Console.Write("Author Name: ");
                            utility.SearchByAuthor(Console.ReadLine());
                            break;
                        case "5":
                            string[] export = utility.ExportToArray();
                            Console.WriteLine($"Exported {export.Length} books.");
                            return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (Exception ex)
                {
                    // Requirement: Handle empty cases and format errors
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
