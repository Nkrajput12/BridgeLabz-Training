using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.HomeAutomation
{
    internal class Light : Appliance, IControllable
    {
        public Light() : base("Lightbulb") { }

        public override void TurnOn()
        {
            if (base.GetStatus() == true)
            {
                Console.WriteLine("Light is already on");
            }
            else
            {
                Console.WriteLine("Light on");
                base.SetStatus(true);
            }

        }

        public override void TurnOff()
        {
            if (base.GetStatus() == true)
            {
                base.SetStatus(false);
                Console.WriteLine("Light off");
            }
            else
            {
                Console.WriteLine("light is already off");
            }
        }
    }
}
