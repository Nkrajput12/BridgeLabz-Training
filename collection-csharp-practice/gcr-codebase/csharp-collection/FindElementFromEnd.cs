using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    internal class FindElementFromEnd
    {
        public static void Main(string[] args)
        {
            FindElementFromEnd finder = new FindElementFromEnd(); //create instance of FindElementFromEnd class
            Console.WriteLine("Enter the elements (comma separated):"); //user input
            string[] input = Console.ReadLine().Split(',');
            //store elements in a list
            List<string> elements = new List<string>();
            foreach (string str in input)
            {
                elements.Add(str.Trim());
            }
            Console.WriteLine("Enter the position from the end:"); //user input for position
            int position = Convert.ToInt32(Console.ReadLine());
            //call FindFromEnd method to find the element
            string result = finder.FindFromEnd(elements, position);
            //print results
            if (result != null)
            {
                Console.WriteLine($"Element at position {position} from the end is: {result}");
            }
            else
            {
                Console.WriteLine("Position is out of bounds.");
            }
        }

        //method to find the element at given position from the end
        public string FindFromEnd(List<string> list, int position)
        {
            int indexFromStart = list.Count - position;
            if (indexFromStart >= 0 && indexFromStart < list.Count)
            {
                return list[indexFromStart];
            }
            return null; //indicates position is out of bounds
        }
    }
}
