using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.ECommercePlatform
{
    public class Electronics : Product,ITaxable
    {
        public Electronics(int id,string name,double price):base(id,name,price) { }

        public override double CalculateDiscount()
        {
            return Price * 0.10;
        }

        public override double CalculateTax()
        {
            return Price * 0.15;
        }

        public string TaxDetails()
        {
            return "electronics tax = 15%";
        }
    }
}
