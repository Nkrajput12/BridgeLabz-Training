using System;

namespace BridgeLabzTraining.access
{
    class Program
    {
        static void Main()
        {
            // Index represents the length in feet, value is the price
            int[] priceList = { 0, 3, 7, 9, 12, 15, 20, 22, 25, 30, 33, 35, 40 };
            int rodLength = 12;

            var calculator = new RodProfitCalculator(priceList);

            // Case 1: Standard calculation
            Console.WriteLine("--- -----Pure Profit Maximization ---");
            calculator.PrintBestCuts(rodLength, cutCost: 0);

            // Case 2: Including labor/waste cost ($2 per cut)
            Console.WriteLine("\n---Profit minus 2 per cut ---");
            calculator.PrintBestCuts(rodLength, cutCost: 2);
        }
    }

    public class RodProfitCalculator
    {
        private readonly int[] _prices;

        public RodProfitCalculator(int[] prices)
        {
            _prices = prices;
        }

        public void PrintBestCuts(int length, int cutCost)
        {
            // dp[i] will store the max profit for a rod of length i
            int[] dp = new int[length + 1];
            // choices[i] stores the length of the first piece cut to get that max profit
            int[] choices = new int[length + 1];

            // Build up the solution from 1ft to the total length
            for (int i = 1; i <= length; i++)
            {
                int maxProfit = -1;

                for (int j = 1; j <= i; j++)
                {
                    if (j >= _prices.Length) continue;

                    // Calculate profit: Price of this piece + max profit of what's left
                    int currentProfit = _prices[j] + dp[i - j];

                    // If we actually had to cut it (meaning there's a remainder), subtract the cost
                    if (i - j > 0)
                    {
                        currentProfit -= cutCost;
                    }

                    if (currentProfit > maxProfit)
                    {
                        maxProfit = currentProfit;
                        choices[i] = j;
                    }
                }
                dp[i] = maxProfit;
            }

            DisplayOutput(length, dp, choices);
        }

        private void DisplayOutput(int totalLength, int[] dp, int[] choices)
        {
            Console.WriteLine($"Length: {totalLength}ft | Max Profit: ${dp[totalLength]}");

            Console.Write("Cuts to make: ");
            int remaining = totalLength;
            int usedLength = 0;

            while (remaining > 0)
            {
                int cut = choices[remaining];
                if (cut == 0) break;

                Console.Write($"{cut}ft ");
                usedLength += cut;
                remaining -= cut;
            }

            int waste = totalLength - usedLength;
            Console.WriteLine($"\nWaste remaining: {waste}ft");
            Console.WriteLine(new string('=', 45));
        }
    }
}