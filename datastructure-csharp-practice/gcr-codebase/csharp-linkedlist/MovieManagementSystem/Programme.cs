using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.MovieManagementSystem
{
    class Program
    {
        static void Main()
        {
            MovieLibrary lib = new MovieLibrary();
            while (true)
            {
                Console.WriteLine("\n MOVIE MANAGEMENT SYSTEM");
                Console.WriteLine("1. Add Movie\n2. Remove Movie\n3. Search by Director\n4. Update Rating\n5. Display All (Forward)\n6. Display All (Reverse)\n7. Exit");
                Console.Write("Selection: ");
                string choice = Console.ReadLine();

                if (choice == "7") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("Title: "); string t = Console.ReadLine();
                        Console.Write("Director: "); string d = Console.ReadLine();
                        Console.Write("Year: "); int y = int.Parse(Console.ReadLine());
                        Console.Write("Rating: "); double r = double.Parse(Console.ReadLine());
                        Console.Write("Position (0 for End): "); int p = int.Parse(Console.ReadLine());

                        if (p == 0) lib.AddEnd(t, d, y, r);
                        else lib.AddAtPosition(p, t, d, y, r);
                        break;

                    case "2":
                        Console.Write("Enter Title to Remove: ");
                        lib.RemoveByTitle(Console.ReadLine());
                        break;

                    case "3":
                        Console.Write("Enter Director Name: ");
                        lib.SearchByDirector(Console.ReadLine());
                        break;

                    case "4":
                        Console.Write("Title: "); string ut = Console.ReadLine();
                        Console.Write("New Rating: "); double ur = double.Parse(Console.ReadLine());
                        lib.UpdateRating(ut, ur);
                        break;

                    case "5": lib.DisplayForward(); break;
                    case "6": lib.DisplayReverse(); break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }
    }
}
