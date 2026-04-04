using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.HomeAutomation
{
    internal class AC : Appliance, IControllable
    {
        public AC(): base("AC") { }

        public override void TurnOn()
        {
            if (base.GetStatus() == true)
            {
                Console.WriteLine("AC is already on");
            }
            else
            {
                Console.WriteLine("AC start");
                base.SetStatus(true);
            }

        }

        public override void TurnOff()
        {
            if (base.GetStatus() == true)
            {
                base.SetStatus(false);
                Console.WriteLine("Ac stop ");
            }
            else
            {
                Console.WriteLine("AC is already off");
            }
        }
    }
}
