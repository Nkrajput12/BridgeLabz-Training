using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Movie_Schedule_Manager
{
    internal class MovieUtility
    {
        private Movie[] movies = new Movie[50];
        private int movieCount = 0;

        public void AddMovie()
        {
            Console.Write("Enter the title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Time (HH:MM)");
            string time = Console.ReadLine();

            if (movieCount > movies.Length)
            {
                throw new IndexOutOfRangeException("Capacity is full");

            }
            else
            {
                if (!Regex.IsMatch(time, @"^([01]\d|2[0-3]):([0-5]\d)$"))
                {
                    throw new InvalidTimeFormatException($"'{time}' is not a valid 24-hour time format.");
                }

                movies[movieCount++] = new Movie(title, time);
                Console.WriteLine("-------Movie added successfully-------");
            }

        }

        public void SearchMovies()
        {
            Console.WriteLine("please enter movie to search: ");
            string keyword = Console.ReadLine();
            bool found = false;
            for(int i = 0;i< movieCount; i++)
            {
                if (movies[i].Title.Contains(keyword))
                {
                    Console.WriteLine(movies[i].ToString());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No match found");
            }
        }

        public void DisplayAll()
        {
            if(movieCount == 0)
            {
                Console.WriteLine("No movie scheduled");
            }
            else
            {
                for(int i = 0; i < movieCount; i++)
                {
                    Console.WriteLine(movies[i]);
                }
            }
        }
    }
}
