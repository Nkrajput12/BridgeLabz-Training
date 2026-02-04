using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.factory_robot_hazard_analyzer
{
    internal class RobotSafetyException : Exception
    {
        public RobotSafetyException(string message): base(message) { }

    }
}
