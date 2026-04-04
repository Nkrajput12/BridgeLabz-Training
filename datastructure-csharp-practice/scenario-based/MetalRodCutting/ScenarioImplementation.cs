using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace BridgeLabzTraining.MetalRodCutting
{
    internal class ScenarioImplementation
    {
        private int[] priceLength;

        public ScenarioImplementation(int[] priceLength)
        {
            this.priceLength = priceLength;
        }

        //Scenario A -- opltimal Revenue and best cuts
        public void FindBestCuts(int n)
        {

            int[] maxrevenue = new int[n + 1]; //strore the maxrevenue at specific position
            int[] bestcuts = new int[n + 1]; //best cuts

            maxrevenue[0] = 0; //the revenue for length 0 is 0

            for (int i = 1; i <= n; i++)
            {
                int currentMax = int.MinValue;
                for (int j = 1; j <= i; j++)
                {
                    if (j < priceLength.Length)
                    {

                        if (currentMax < priceLength[j] + maxrevenue[i - j]) //check if current price is less than price for lenght j and maxrevenue [i-j]
                        {
                            currentMax = priceLength[j] + maxrevenue[i - j]; //update currentmax
                            bestcuts[i] = j; //best cut for specific lenght
                        }
                    }
                }
                maxrevenue[i] = currentMax;
            }

            Console.WriteLine("the maximum revenue for lenght " + n + " is" + maxrevenue[n]);
            Console.WriteLine("best cut at ");
            int temp = n;
            while (temp > 0)
            {
                Console.Write(bestcuts[temp] + " ");
                temp -= bestcuts[temp];

            }
            Console.WriteLine();    
        }
        

        // Scenario B: Update price for a specific length
        public void AddCustomOrder(int length, int newPrice, int totalRodLength)
        {
            Console.WriteLine($"--- Adding Custom Order (Length {length} and  Price {newPrice}) ---");

            

            priceLength[length] = newPrice;
            FindBestCuts(totalRodLength);
        }

        // Scenario C: Greedy aproach
        public void Greedy(int n)
        {
            Console.WriteLine("---  Optimization Comparison ---");
            //"Greedy" always take the longest piece first
            int greedyRevenue = 0;
            if (n < priceLength.Length) greedyRevenue = priceLength[n];

            Console.WriteLine($"Greedy (Single Cut) Revenue: {greedyRevenue}");
            
        }
    }
}