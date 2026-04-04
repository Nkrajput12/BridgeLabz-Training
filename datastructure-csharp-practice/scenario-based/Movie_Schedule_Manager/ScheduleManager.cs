using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Movie_Schedule_Manager
{
    internal class ScheduleManager
    {
        public static void Main(string[] args)
        {
            MoviesMenu menu = new MoviesMenu();
            menu.RunMenu();
        }
    }
}
