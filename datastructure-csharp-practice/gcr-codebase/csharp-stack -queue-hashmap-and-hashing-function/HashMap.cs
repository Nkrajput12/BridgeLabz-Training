using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    public class HashNode
    {
        public int k;
        public string v;
        public HashNode next;

        public HashNode(int key, string val)
        {
            this.k = key;
            this.v = val;
            this.next = null;
        }
    }

    
    public class SimpleHashTable
    {
        private HashNode[] table;
        private int size;

        public SimpleHashTable(int capacity)
        {
            this.size = capacity;
            this.table = new HashNode[capacity];
        }

        //find the index
        private int GetHash(int key)
        {
            return Math.Abs(key) % size;
        }

        // Put/Add operation
        public void Put(int key, string val)
        {
            int index = GetHash(key);
            HashNode current = table[index];

            // Traverse list to check for existing key
            while (current != null)
            {
                if (current.k == key)
                {
                    current.v = val;
                    return;
                }
                current = current.next;
            }

            // Not found, so add new node at the head
            HashNode newNode = new HashNode(key, val);
            newNode.next = table[index];
            table[index] = newNode;
        }

        public string Get(int key)
        {
            int index = GetHash(key);
            HashNode temp = table[index];

            while (temp != null)
            {
                if (temp.k == key) return temp.v;
                temp = temp.next;
            }

            return "Key not found";
        }

        public void Remove(int key)
        {
            int index = GetHash(key);
            HashNode current = table[index];
            HashNode prev = null;

            while (current != null)
            {
                if (current.k == key)
                {
                    if (prev == null)
                        table[index] = current.next;
                    else
                        prev.next = current.next;
                    return;
                }
                prev = current;
                current = current.next;
            }
        }

        // Added this to help visualize 
        public void ShowTable()
        {
            Console.WriteLine("\n--- Current Table Map ---");
            for (int i = 0; i < size; i++)
            {
                Console.Write("Index " + i + ": ");
                HashNode temp = table[i];
                while (temp != null)
                {
                    Console.Write("[" + temp.k + ":" + temp.v + "] -> ");
                    temp = temp.next;
                }
                Console.WriteLine("null");
            }
        }
    }

    class ProjectMain
    {
        static void Main(string[] args)
        {
            SimpleHashTable myHash = new SimpleHashTable(5);

            myHash.Put(10, "Apple");
            myHash.Put(20, "Banana");
            myHash.Put(15, "Cherry"); 
            myHash.Put(7, "Dates");

            myHash.ShowTable();

            Console.WriteLine("\nSearching for Key 20: " + myHash.Get(20));

            myHash.Remove(10);
            Console.WriteLine("Removing Key 10...");

            myHash.ShowTable();
        }
    }
}
