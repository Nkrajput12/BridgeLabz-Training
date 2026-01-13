using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Movie_Schedule_Manager
{
    internal class MoviesMenu
    {
        MovieUtility utility = new MovieUtility();
        
        public void RunMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Cinema Time Manager ---");
                Console.WriteLine("Press 1. Add Movie");
                Console.WriteLine("Press 2. View All Movies");
                Console.WriteLine("Press 3. Search Movie");
                Console.WriteLine("Press 4. Exit");
                Console.Write("Select an option: ");
                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1: utility.AddMovie(); break;
                        case 2: utility.DisplayAll(); break;
                        case 3: utility.SearchMovies(); break;
                        case 4: exit = true; break;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(InvalidTimeFormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                }
            }
        }
    }
}
