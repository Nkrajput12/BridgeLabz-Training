using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.data_structure.QueueUsingStack
{
    internal class QueueImplementation
    {
        public static void Main(string[] args)
        {
            Queue queue = new Queue();

            //inserting the elements to the queue
            queue.Enqueue("Hello");
            queue.Enqueue("World");
            queue.Enqueue("Ram");
            queue.Enqueue("Ram");
            queue.Enqueue("Hello");
            queue.Enqueue("4");

            //return and dequeue the elements from the queue
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

        }
    }
}
