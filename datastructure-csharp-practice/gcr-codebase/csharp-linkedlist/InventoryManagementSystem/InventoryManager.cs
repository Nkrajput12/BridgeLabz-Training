using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.InventoryManagementSystem
{
    public class InventoryManager
    {
        private InventoryItem head = null;

        // Add Item (Beginning, End, or Position)
        public void AddBeginning(int id, string name, int qty, double price)
        {
            InventoryItem newItem = new InventoryItem(id, name, qty, price);
            newItem.Next = head;
            head = newItem;
        }

        public void AddEnd(int id, string name, int qty, double price)
        {
            InventoryItem newItem = new InventoryItem(id, name, qty, price);
            if (head == null) { head = newItem; return; }
            InventoryItem temp = head;
            while (temp.Next != null) temp = temp.Next;
            temp.Next = newItem;
        }

        public void AddAtPosition(int pos, int id, string name, int qty, double price)
        {
            if (pos <= 1) { AddBeginning(id, name, qty, price); return; }
            InventoryItem newItem = new InventoryItem(id, name, qty, price);
            InventoryItem temp = head;
            for (int i = 1; temp != null && i < pos - 1; i++) temp = temp.Next;

            if (temp == null) AddEnd(id, name, qty, price);
            else
            {
                newItem.Next = temp.Next;
                temp.Next = newItem;
            }
        }

        // Remove by Item ID
        public void RemoveByID(int id)
        {
            if (head == null) return;
            if (head.ItemID == id) { head = head.Next; return; }

            InventoryItem current = head;
            while (current.Next != null && current.Next.ItemID != id)
                current = current.Next;

            if (current.Next != null) current.Next = current.Next.Next;
            else Console.WriteLine("ID not found.");
        }

        //Update Quantity
        public void UpdateQuantity(int id, int newQty)
        {
            InventoryItem temp = head;
            while (temp != null)
            {
                if (temp.ItemID == id) { temp.Quantity = newQty; return; }
                temp = temp.Next;
            }
            Console.WriteLine("ID not found.");
        }

        // Search by ID or Name
        public void Search(string query)
        {
            InventoryItem temp = head;
            bool found = false;
            while (temp != null)
            {
                if (temp.ItemID.ToString() == query || temp.ItemName.Equals(query, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found: {temp.ItemName} (ID: {temp.ItemID}) | Qty: {temp.Quantity} | Price: {temp.Price}");
                    found = true;
                }
                temp = temp.Next;
            }
            if (!found) Console.WriteLine("No results found.");
        }

        //Calculate Total Inventory Value
        public void DisplayTotalValue()
        {
            double total = 0;
            InventoryItem temp = head;
            while (temp != null)
            {
                total += (temp.Price * temp.Quantity);
                temp = temp.Next;
            }
            Console.WriteLine($"\n>>> Total Inventory Value: {total:F2}");
        }

        public void DisplayAll()
        {
            if (head == null) { Console.WriteLine("Inventory is empty."); return; }
            InventoryItem temp = head;
            Console.WriteLine("\nID\tName\t\tQty\tPrice\tTotal");
            while (temp != null)
            {
                Console.WriteLine($"{temp.ItemID}\t{temp.ItemName}\t\t{temp.Quantity}\t{temp.Price}\t{(temp.Price * temp.Quantity):F2}");
                temp = temp.Next;
            }
        }
    }
}
