using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.ResumeAnalyzer
{
    internal class AnMenu
    {
        Analyzerutil util = new Analyzerutil();
        
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Write("1. Analyze | 2. Display result | 3. exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        util.StartAnalyse();
                        break;
                    case "2":
                        util.Display();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.Write("Invalid Choice");
                        break;

                }
            }
        }
    }
}
