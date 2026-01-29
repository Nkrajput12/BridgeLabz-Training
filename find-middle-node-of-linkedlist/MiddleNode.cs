using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//Question: Find the Middle of the Liked list using recursion

namespace BridgeLabzTraining
{

    public class Node
    {
        public int Data;
        public Node Next;
        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
        }
    }

    public class LinkedList
    {
        private Node Head;

        //Method to Add element to the Node
        public void Add(int data)
        {
            Node newNode = new Node(data);
            if(Head == null)
            {
                Head = newNode;
                return;
            }
            Node temp = Head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;

        }

        //method to display the linkedlist
        public void Display()
        {
            if(Head == null)
            {
                Console.WriteLine("Linked list is empty!");
            }
            Node temp = Head;
            while(temp != null)
            {
                Console.Write(temp.Data + " ==> ");
                temp = temp.Next;
            }
            Console.WriteLine("Null");
        }

        //method to find Middle Node
        public void FindMiddle()
        {
            if(Head == null)
            {
                Console.WriteLine("Empty linked list");
                return;
            }
            Node temp = Head;
            Node mid = Head;
            int count = 1;
            Traverse(mid, count, temp);
                         
        }

        public void Traverse(Node mid, int count, Node temp)
        {
            if (temp.Next == null)
            {
                Console.WriteLine("Middle Node: " + mid.Data);
                return;
            }

            count++;
            if (count % 2 != 0)
            {
                mid = mid.Next;
            }

            temp = temp.Next;
            Traverse(mid, count, temp);
        }



    }
    
    internal class MiddleNode
    {
        public static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Press 1: to add element");
                Console.WriteLine("Press 2: to Display elements");
                Console.WriteLine("Press 3: to find middle Node");
                Console.WriteLine("Press 4: to exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Here: ");
                        list.Add(int.Parse(Console.ReadLine()));
                        break;

                    case 2:
                        list.Display();
                        break;

                    case 3:
                        list.FindMiddle();
                        break;

                    case 4:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }
        

            }
        }
    }
}
