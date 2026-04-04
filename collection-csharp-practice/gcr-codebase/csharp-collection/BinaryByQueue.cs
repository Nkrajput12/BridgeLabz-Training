//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraining.access
//{
//    internal class BinaryByQueue
//    {
//        public static void Main(string[] args)
//        {
//            Console.WriteLine("Enter a number to generate binary numbers up to that number:");
//            int n = int.Parse(Console.ReadLine());
//            GenerateBinaryNumbers(n);
//        }
//        public static void GenerateBinaryNumbers(int n)
//        {
//            Queue<string> queue = new Queue<string>();
//            queue.Enqueue("1");
//            for (int i = 0; i < n; i++)
//            {
//                string front = queue.Dequeue();
//                Console.WriteLine(front);
//                queue.Enqueue(front + "0");
//                queue.Enqueue(front + "1");
//            }
//        }
//    }
//}
