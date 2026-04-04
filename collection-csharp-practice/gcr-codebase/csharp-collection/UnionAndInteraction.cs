using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    internal class UnionAndInteraction
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

            //find the union of the two sets
            HashSet<string> temp = new HashSet<string>(set1); //create a temporary copy of set1
            temp.UnionWith(set2);
            Console.WriteLine("Union of the two sets:");
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }

            //find the intersection of the two sets
            temp = set1; //reset temp to original set1
            temp.IntersectWith(set2);
            Console.WriteLine("Intersection of the two sets:");
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
        }
    }
}
