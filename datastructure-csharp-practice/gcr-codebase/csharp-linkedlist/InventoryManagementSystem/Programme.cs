using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.InventoryManagementSystem
{
    class Program
    {
        static void Main()
        {
            InventoryManager inv = new InventoryManager();
            while (true)
            {
                Console.WriteLine("\n INVENTORY MANAGEMENT SYSTEM");
                Console.WriteLine("1. Add Item\n2. Remove Item\n3. Update Quantity\n4. Search Item\n5. View Total Value\n6. Display All\n7. Exit");
                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();

                if (choice == "7") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("Item ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Item Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Quantity: "); 
                        int qty = int.Parse(Console.ReadLine());
                        Console.Write("Price: "); 
                        double pr = double.Parse(Console.ReadLine());
                        Console.WriteLine("Insert at: 1. Beginning  2. End  3. Position");
                        string sub = Console.ReadLine();
                        if (sub == "1") inv.AddBeginning(id, name, qty, pr);
                        else if (sub == "2") inv.AddEnd(id, name, qty, pr);
                        else
                        {
                            Console.Write("Enter Position: ");
                            inv.AddAtPosition(int.Parse(Console.ReadLine()), id, name, qty, pr);
                        }
                        break;

                    case "2":
                        Console.Write("Enter Item ID to remove: ");
                        inv.RemoveByID(int.Parse(Console.ReadLine()));
                        break;

                    case "3":
                        Console.Write("Enter Item ID: "); 
                        int uId = int.Parse(Console.ReadLine());
                        Console.Write("New Quantity: "); 
                        int uQty = int.Parse(Console.ReadLine());
                        inv.UpdateQuantity(uId, uQty);
                        break;

                    case "4":
                        Console.Write("Enter ID or Name to search: ");
                        inv.Search(Console.ReadLine());
                        break;

                    case "5":
                        inv.DisplayTotalValue();
                        break;

                    case "6":
                        inv.DisplayAll();
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
