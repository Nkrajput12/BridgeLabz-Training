using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    internal class RemoveDuplicate
    {
        public static void Main(string[] args)
        {
            RemoveDuplicate remover = new RemoveDuplicate(); //create instance of RemoveDuplicate class
            Console.WriteLine("Enter the elements (comma separated):"); //user input
            string[] input = Console.ReadLine().Split(',');
            //store elements in a list
            List<int> elements = new List<int>();
            foreach (string str in input)
            {
                elements.Add(Convert.ToInt32(str.Trim()));
            }
            //call RemoveDuplicates method to remove duplicates
            List<int> uniqueElements = remover.RemoveDuplicates(elements);
            //print results
            Console.WriteLine("List after removing duplicates:");
            foreach (int num in uniqueElements)
            {
                Console.Write(num + " ");
            }
        }

        //method to remove duplicates from the list
        public List<int> RemoveDuplicates(List<int> list)
        {
            //use hashset to track seen elements
            HashSet<int> seen = new HashSet<int>();
            List<int> uniqueList = new List<int>();
            foreach (int item in list)
            {
                if (!seen.Contains(item))
                {
                    seen.Add(item);
                    uniqueList.Add(item);
                }
            }
            return uniqueList;
        }
    }
}
