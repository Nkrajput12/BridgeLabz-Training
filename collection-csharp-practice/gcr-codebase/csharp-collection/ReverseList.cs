using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    internal class ReverseList
    {
        public static void Main(string[] args)
        {
            ReverseList list = new ReverseList();
            Console.WriteLine("enter the elements (comma seperated)");
            string[] input = Console.ReadLine().Split(',');

            //----------------using ArrayList----------------
            List<int> arraylist = new List<int>();
            foreach (string str in input)
            {
                arraylist.Add(Convert.ToInt32(str.Trim()));
            }
            arraylist = list.ReversetheList(arraylist);
            Console.WriteLine("\nReversed List is:");
            foreach (int num in arraylist)
            {
                Console.Write(num + " ");
            }

            //----------------- using LinkedList----------------
            LinkedList<int> linkedlist = new LinkedList<int>();
            foreach (string str in input)
            {
                linkedlist.AddLast(Convert.ToInt32(str.Trim()));
            }
            linkedlist = list.ReversetheLinkedList(linkedlist);
            Console.WriteLine("\nReversed Linked List is:");
            foreach (int num in linkedlist)
            {
                Console.Write(num + " ");
            }


        }

        //method to reverse the list
        public List<int> ReversetheList(List<int> list)
        {
            int start = 0;
            int end = list.Count - 1;
            while (start <= end)
            {
                int temp = list[start];
                list[start] = list[end];
                list[end] = temp;
                start++;
                end--;
            }

            return list;
        }


        //method to reverse the linked list
        public LinkedList<int> ReversetheLinkedList(LinkedList<int> list)
        {
            LinkedList<int> reversed = new LinkedList<int>();
            LinkedListNode<int> current = list.Last;
            while (current != null)
            {
                reversed.AddLast(current.Value);
                current = current.Previous;
            }
            return reversed;
        }
    }

}
