using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.MetalRodCutting
{
    internal class RodLength
    {
        public static void Main(string[] args)
        {
            // Index represents length, value represents price
            int[] priceChart = { 0, 1, 5, 8, 9, 10, 17, 17, 20 };
            int rodSize = 8;

            ScenarioImplementation rod = new ScenarioImplementation(priceChart);

            // Scenario A
            rod.FindBestCuts(rodSize);

            // Scenario B: 
            rod.AddCustomOrder(2,12, rodSize);

            // Scenario C
            rod.Greedy(rodSize);
        }
    }
}
