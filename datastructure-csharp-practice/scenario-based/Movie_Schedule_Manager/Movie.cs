using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Movie_Schedule_Manager
{
    public class Movie
    {
        public string Title { get; set; }
        public string Showtime { get; set; }

        public Movie(string title, string showtime)
        {
            Title = title;
            Showtime = showtime;
        }

        public override string ToString()
        {
            return $"Movie: {Title,-10} | Time: {Showtime}";
        }
    }
}
