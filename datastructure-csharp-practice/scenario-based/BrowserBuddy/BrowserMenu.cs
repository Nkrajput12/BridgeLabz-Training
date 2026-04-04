using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.BrowserBuddy
{
    internal class BrowserMenu
    {
        public void ShowMenu(BrowserHistory history, ClosedTab tab)
        {
            while (true) //loop run until user press for exit
            {
                //provide choices to user
                Console.WriteLine($"\n--- BrowserBuddy ---");
                Console.WriteLine($"Current Tab: {history.GetCurrent()}");
                Console.WriteLine("Press 1. Visit New site");
                Console.WriteLine("Press 2. Back");
                Console.WriteLine("Press 3. Forward");
                Console.WriteLine("Press 4. Close and save Current Tab ");
                Console.WriteLine("Press 5. Restore Last Closed Tab");
                Console.WriteLine("Press 6. Exit");
                Console.Write("Choice: ");
                //taking user choice
                int choice = int.Parse(Console.ReadLine());
                //run the function according to the user choice
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Url: ");
                        history.visit(Console.ReadLine()); //visit new site
                        break;
                    case 2:
                        Console.WriteLine("Moved back: " + history.backwards());//move backward
                        break;
                    case 3:
                        Console.WriteLine("Moved forword: "+history.forward()); //move forward
                        break;
                    case 4:
                        tab.Push(history.GetCurrent()); //push the current tab to stack
                        Console.WriteLine("Tab closed and saved to stack");
                        history.backwards(); //close the tab by moving backword
                        break;
                    case 5:
                        string restore = tab.Pop(); //remove and return the top of the stack
                       
                        if(restore != null) //check if restore is null or not
                        {
                            history.visit(restore); //visit the restore site
                            Console.WriteLine("Restored: "+restore);
                        }
                        else //if restore is null
                        {
                            Console.WriteLine("No tab to restore");
                        }
                        break;
                    case 6:
                        return; //exit from the loop


                }
            }
        }
    }
}
