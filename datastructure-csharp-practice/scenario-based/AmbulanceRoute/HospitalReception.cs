using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AmbulanceRoute
{
    internal class HospitalReception
    {
       
        public void Run(RouteManager manager)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Press 1: Add Building");
                Console.WriteLine("Press 2: Remove for Maintanance");
                Console.WriteLine("Press 3: Find Nearest Available Unit and add patient");
                Console.WriteLine("Press 4: Display all Unit");
                Console.WriteLine("Press 5: Exit");
                Console.Write("Input: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Capacity: ");
                        int capacity = int.Parse(Console.ReadLine());
                        manager.AddBuilding(name, capacity);
                        break;

                    case 2:
                        Console.Write("Enter Name: ");
                        string buildingname = Console.ReadLine();
                        manager.RemvoveForMaintanace(buildingname);
                        break;

                    case 3:
                        Console.Write("Enter the Stating Point: ");
                        string start = Console.ReadLine();
                        manager.FindNearestunit(start);
                        break;

                    case 4:
                        manager.Display();
                        break;

                    case 5:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                        
                }
            }
        }
    }
}
