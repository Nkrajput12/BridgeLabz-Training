using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.BrowserBuddy
{
    internal class Browser
    {
        public static void Main(string[] args)
        {
            BrowserHistory history = new BrowserHistory("google.com"); //creating object of history with searh enging google
            ClosedTab tab = new ClosedTab(); //creting a object of close tab
            BrowserMenu menu = new BrowserMenu(); //object of menu

            //run showMenu method
            menu.ShowMenu(history,tab);



        }
    }
}
