//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraining.access
//{
//    internal class ReverseAQueue
//    {
//        public static void Main(string[] args)
//        {
//            Queue<int> queue = new Queue<int>();
//            Console.WriteLine("Enter the number of elements in the queue:");
//            int n = int.Parse(Console.ReadLine());
//            Console.WriteLine("Enter the elements of the queue:");
//            for (int i = 0; i < n; i++)
//            {
//                int element = int.Parse(Console.ReadLine());
//                queue.Enqueue(element);
//            }
//            //reverse the queue using queue operations
//             Queue<int> reversedQueue = ReverseQueue(queue);

//            //print results
//            Console.WriteLine("Reverse Queue elements:");
//            foreach(int item in reversedQueue)
//            {
//                Console.Write(item + " ");
//            }
//        }

//        //method to reverse the queue
//        public static Queue<int> ReverseQueue(Queue<int> queue)
//        {
//            Stack<int> stack = new Stack<int>();
//            // Dequeue all elements from the queue and push them onto the stack
//            while (queue.Count > 0)
//            {
//                stack.Push(queue.Dequeue());
//            }
//            // Pop all elements from the stack and enqueue them back to the queue
//            while (stack.Count > 0)
//            {
//                queue.Enqueue(stack.Pop());
//            }
//            Console.WriteLine("Reversed Queue:");
//            foreach (int item in queue)
//            {
//                Console.Write(item + " ");
//            }
//            return queue;
//        }
//    }
//}
