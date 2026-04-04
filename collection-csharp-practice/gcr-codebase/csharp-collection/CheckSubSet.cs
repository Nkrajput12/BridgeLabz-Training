using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    internal class CheckSubSet
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter elements of first set (comma separated):"); //user input
            string[] input1 = Console.ReadLine().Split(','); //read user input
            Console.WriteLine("Enter elements of second set (comma separated):"); //user input
            string[] input2 = Console.ReadLine().Split(','); //read user input
            //store the elements in HashSet
            HashSet<string> set1 = new HashSet<string>(input1);
            HashSet<string> set2 = new HashSet<string>(input2);
            bool isSubset = set1.IsSubsetOf(set2); //check if set1 is subset of set2
            if (isSubset)
            {
                Console.WriteLine("The first set is a subset of the second set.");
            }
            else
            {
                Console.WriteLine("The first set is not a subset of the second set.");
            }
        }
    }
}
