using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.data_structure.QueueUsingStack
{
    internal class StackSort
    {
        // The main function that empties the stack
        public void Sort(Stack<int> stack)
        {
            // check If stack is empty, stop
            if (stack.Count == 0) return;

            // Remove the top element
            int top = stack.Pop();

            // Recursively sort the rest of the stack
            Sort(stack);

            // Put the removed element back in the right spot
            SortedInsert(stack, top);
        }

        // method to insert the element to the stack
        private void SortedInsert(Stack<int> stack, int currentValue)
        {
            // If stack is empty OR currentValue is bigger than the top, push it
            if (stack.Count == 0 || currentValue > stack.Peek())
            {
                stack.Push(currentValue);
                return;
            }

            // If currentValue is smaller, the top is in the way!
            // Take the top out temporarily
            int temp = stack.Pop();

            // Recursively try to insert currentValue again
            SortedInsert(stack, currentValue);

            // Put the temporary element back on top
            stack.Push(temp);
        }
    


        public static void Main(string[] args)
        {
            StackSort sort = new StackSort();
            Stack<int> stack = new Stack<int>();

            stack.Push(13);
            stack.Push(14);
            stack.Push(11);
            stack.Push(6);
            stack.Push(1);
            stack.Push(18);
            stack.Push(15);
            stack.Push(3);

            Console.WriteLine("Stack before sorting");
            foreach(int c in stack)
            {
                Console.WriteLine(c);
            }

            sort.Sort(stack);

            Console.WriteLine("Stack after sorting");
            
            foreach (int c in stack)
            {
                Console.WriteLine(c);
            }

        }
    }
}
