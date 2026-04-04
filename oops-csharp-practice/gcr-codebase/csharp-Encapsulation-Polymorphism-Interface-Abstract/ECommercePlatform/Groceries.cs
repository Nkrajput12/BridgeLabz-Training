using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.ECommercePlatform
{
    public class Groceries : Product
    {
        public Groceries(int id, string name, double price) : base(id, name, price) { }

        public override double CalculateDiscount()
        {
            // Groceries have very low margins; only 2% discount
            return Price * 0.02;
        }
        public override double CalculateTax()
        {
            return 0;
        }
    }
}
