using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    internal class SymmetricDifference
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


            //find the symmetric difference of the two sets
            HashSet<string> temp1 = new HashSet<string>(set1); //create a temporary copy of set1
            temp1.ExceptWith(set2); //remove elements of set2 from temp1
            HashSet<string> temp2 = new HashSet<string>(set2); //create a temporary copy of set2
            temp2.ExceptWith(set1); //remove elements of set1 from temp2
            temp1.UnionWith(temp2); //combine the two results to get symmetric difference
            Console.WriteLine("Symmetric Difference of the two sets:");
            foreach (var item in temp1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
