using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.HomeAutomation
{
    internal class Fan : Appliance, IControllable
    {
        public Fan() : base("Fan")
        {
        }
        public override void  TurnOn()
        {
            if(base.GetStatus() == true)
            {
                Console.WriteLine("Fan is already on");
            }
            else
            {
                Console.WriteLine("fan start Rotating");
                base.SetStatus(true);
            }
            
        }

        public override void TurnOff()
        {
            if(base.GetStatus() == true)
            {
                base.SetStatus(false);
                Console.WriteLine("Fan stop Rotating");
            }
            else
            {
                Console.WriteLine("Fan is already off");
            }
        }
    }
}
