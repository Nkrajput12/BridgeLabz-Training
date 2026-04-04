using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AmbulanceRoute
{
    internal class Hospital
    {
        public static void Main(string[] args)
        {
            RouteManager manager= new RouteManager();
            HospitalReception menu = new HospitalReception();
            manager.AddBuilding("Emergency", 7);
            manager.AddBuilding("Radiology", 1);
            manager.AddBuilding("Surgery", 2);
            manager.AddBuilding("ICU", 5);


            menu.Run(manager);
        }
    }
}
