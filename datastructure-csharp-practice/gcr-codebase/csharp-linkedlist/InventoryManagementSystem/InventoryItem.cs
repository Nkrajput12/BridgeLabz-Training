using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.InventoryManagementSystem
{
    public class InventoryItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public InventoryItem Next { get; set; }

        public InventoryItem(int id, string name, int qty, double price)
        {
            ItemID = id;
            ItemName = name;
            Quantity = qty;
            Price = price;
            Next = null;
        }
    }
}
