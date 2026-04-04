using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.HomeAutomation
{
    public abstract class Appliance : IControllable
    {
        private bool Status = false;
        public string Type;
        public void SetStatus(bool status)
        {
            Status = status;
        }
        public bool GetStatus()
        {
            return Status;
        }
        public Appliance(string type)
        {
            this.Type=type;
        }

        public abstract void TurnOn();
        public abstract void TurnOff();

    }
}
