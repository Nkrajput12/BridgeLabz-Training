using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.MovieManagementSystem
{
    public class MovieNode
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }

        public MovieNode Next { get; set; }
        public MovieNode Prev { get; set; }

        public MovieNode(string title, string director, int year, double rating)
        {
            Title = title;
            Director = director;
            Year = year;
            Rating = rating;
            Next = null;
            Prev = null;
        }
    }
}
