using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.HomeAutomation
{
    internal class ApplianceMenu
    {
        public void Run()
        {
            Appliance fan = new Fan();
            Appliance ac = new AC();
            Appliance light = new Light();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("press 1 to turn on Fan");
                Console.WriteLine("press 2 to turn on Fan");
                Console.WriteLine("press 3 to turn on Light");
                Console.WriteLine("press 4 to turn on Light");
                Console.WriteLine("press 5 to turn on AC");
                Console.WriteLine("press 6 to turn on AC");
                Console.WriteLine("press 7 to exit");
                Console.Write("Input here: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        fan.TurnOn();
                        break;
                    case 2: 
                        fan.TurnOff(); 
                        break;
                    case 3:
                        light.TurnOn();
                        break;
                    case 4:
                        light.TurnOff();
                        break;
                    case 5:
                        ac.TurnOn();
                        break;
                    case 6:
                        ac.TurnOff();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
