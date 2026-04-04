using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.data_structure.QueueUsingStack
{
    internal class Queue
    {
        private Stack<string> stackIn = new Stack<string> (); //stack in for insertion
        private Stack<string> stackOut = new Stack<string> (); //stack out for get the fist element 

        //method to count the element inside queue
        public int Count()
        {
            return stackIn.Count+stackOut.Count;
        }

        //method to add element in a queue at last
        public void Enqueue(string item)
        {
            stackIn.Push (item);
        }

        //method to return and remove the first element of the queue
        public string Dequeue()
        {
            MoveElements();
            if (stackOut.Count == 0)
            {
                Console.WriteLine("stack is empty");
                return null;
            }
            return stackOut.Pop();
        }

        //method to get the first element of the Queue
        public string peek()
        {
            MoveElements ();
            if(stackOut.Count == 0)
            {
                Console.WriteLine("stack is empty");
                return null;
            }
            return stackOut.Peek();
        }


        //method to move elements from stackIn to stackOut
        private void MoveElements()
        {
            if(stackOut.Count == 0)
            {
                while(stackIn.Count > 0)
                {
                    stackOut.Push(stackIn.Pop());
                }
            }
        }
    }
}
