using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Movie_Schedule_Manager
{
    internal class InvalidTimeFormatException : Exception
    {
        public InvalidTimeFormatException(string Message) : base(Message) { }
    }
}
