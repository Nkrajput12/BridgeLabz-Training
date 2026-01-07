using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.ECommercePlatform
{
    public class Clothing : Product, ITaxable
    {
        public Clothing(int id, string name, double price) : base(id, name, price) { }

        public override double CalculateDiscount()
        {
            
            return 5.00;
        }

        public override double CalculateTax()
        {
            return Price * 0.05; 
        }

        public string TaxDetails()
        {
            return "Clothing  Tax  = 5%";
        }
    }
}
