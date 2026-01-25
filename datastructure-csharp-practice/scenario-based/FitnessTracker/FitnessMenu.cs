using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.FitnessTracker
{
    internal class FitnessMenu
    {
        public void Run()
        {
            CounterUtility utility = new CounterUtility();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Press 1: to add Coustumer");
                Console.WriteLine("Press 2: to generate steps");
                Console.WriteLine("Press 3: to display leaderboard");
                Console.WriteLine("Press 4: to exit ");
                Console.Write("Input Here: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        utility.AddCustomer();
                        break;

                    case 2:
                        utility.GenerateStep();
                        break;

                    case 3:
                        utility.DisplayLeaderboard();
                        break;

                    case 4:
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
