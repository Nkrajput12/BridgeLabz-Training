using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    
    public class StockSpanProvider
    {
        public static int[] CalculateSpan(int[] prices)
        {
            int n = prices.Length;
            int[] span = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                // Pop elements from stack while stack is not empty 
                // and the current price is greater than the price at stack top index
                while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
                {
                    stack.Pop();
                }

                // If stack is empty, then price[i] is greater than all previous elements
                
                span[i] = (stack.Count == 0) ? (i + 1) : (i - stack.Peek());

                // Push this element's index to stack
                stack.Push(i);
            }

            return span;
        }

        public static void Main()
        {
            int[] prices = { 100, 80, 60, 70, 60, 75, 85 };
            int[] result = CalculateSpan(prices);

            Console.WriteLine("Prices: " + string.Join(", ", prices));
            Console.WriteLine("Spans:  " + string.Join(", ", result));
        }
    }
}
