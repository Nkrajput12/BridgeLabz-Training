using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.ECommercePlatform
{
    public interface ITaxable
    {
        double CalculateTax();
        String TaxDetails();
    }
}
