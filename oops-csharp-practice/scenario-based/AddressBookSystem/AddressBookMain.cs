using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AddressBookSystem
{
    internal class AddressBookMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-----Welcome to Address Book Programme-----");
            AddressBookMenu menu = new AddressBookMenu();
            menu.Run();
        }
    }
}
