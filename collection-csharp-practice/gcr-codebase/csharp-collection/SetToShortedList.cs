using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    internal class SetToShortedList
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Enter the elements of the set (comma separated):"); //user input
            string[] input = Console.ReadLine().Split(','); //read user input
            HashSet<int> numberSet = new HashSet<int>();

            foreach (string s in input)
            {
                // You must convert the string to an int first
                if (int.TryParse(s.Trim(), out int result))
                {
                    numberSet.Add(result);
                }
            }
            ;
            List<int> list = new List<int>();
            foreach (int number in numberSet)
            {
                list.Add(number); //add elements to linked list
            }

            list.Sort(); //sort the list


            //print results\
            Console.WriteLine("The sorted list is:");
            foreach (int num in list)
            {
                Console.Write(num + " ");
            }




        }
    }
}
