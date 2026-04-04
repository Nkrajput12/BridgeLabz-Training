using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.factory_robot_hazard_analyzer
{
    internal class HazardAnalyzer
    {
        public static void Main(string[] args)
        {
            Analyzer analyer = new Analyzer();
            try
            {
                analyer.Run();
            }
            catch(RobotSafetyException ex)
            {
                Console.WriteLine(ex);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unexpected exception: " + ex);
            }
        }
    }
}
