using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.factory_robot_hazard_analyzer
{
    internal class Analyzer
    {
        public void Run()
        {
            Console.WriteLine("Enter Arm Precision(0.0-1.0)");
            double armPrecision = Convert.ToDouble(Console.ReadLine());
            if(armPrecision < 0.0 || armPrecision > 1.0)
            {
                throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
            }

            Console.WriteLine("Enter Worker Density(1-20)");
            int worker = Convert.ToInt32(Console.ReadLine());
            if(worker < 1 || worker > 20)
            {
                throw new RobotSafetyException("Error: Worker density must be 1-20");
            }

            Console.WriteLine("Enter Machinery State(Worm/Faulty/Critical)");
            string state = Console.ReadLine();
            if(!(state.Equals("Worm") || state.Equals("Faulty") || state.Equals("Critical")))
            {
                throw new RobotSafetyException("Error: Unsupported machinery state");
            }
            Analyzer analyzer = new Analyzer();
            double risk = analyzer.CalculateHazardRisk(armPrecision, worker, state);

            Console.WriteLine("Robot Hazard Risk Score: " + risk);
        }

        public double CalculateHazardRisk(double armPrecision,int workerDensity, string state)
        {
            double machineRiskFactor = 0;
            switch (state)
            {
                case "Worn":
                    machineRiskFactor = 1.3;
                    break;
                case "Faulty":
                    machineRiskFactor = 2.0;
                    break;
                case "Critical":
                    machineRiskFactor = 3.0;
                    break;
            }

            double hazardRisk = (((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor));

            return hazardRisk;
        }
    }
}
