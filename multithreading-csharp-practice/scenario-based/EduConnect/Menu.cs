using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.EduConnect
{
    internal class Menu
    {
        EduUtility util = new EduUtility();

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Press 1: For apply");
                Console.WriteLine("Press 2: Status");
                Console.WriteLine("Press 3: Exit");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    util.Add();
                }
                else if (choice == "2")
                {
                    Console.Write("Enter application Id: ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    util.Display(Id);
                }
                else if(choice == "3")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}

