using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    internal class RotateElement
    {
        public static void Main(string[] args)
        {
            RotateElement rotate = new RotateElement(); //create instance of RotateElement class
            Console.WriteLine("Enter the elements (comma separated):"); //user input
            string[] input = Console.ReadLine().Split(',');
            //store elements in a list
            List<int> elements = new List<int>();
            foreach (string str in input)
            {
                elements.Add(Convert.ToInt32(str.Trim()));
            }
            Console.WriteLine("Enter number of positions to rotate:"); //user input for positions
            int positions = Convert.ToInt32(Console.ReadLine());

            //call RotateList method to rotate the list
            List<int> rotatedList = rotate.RotateList(elements, positions);

            //print results
            Console.WriteLine("Rotated List:");
            foreach (int num in rotatedList)
            {
                Console.Write(num + " ");
            }
        }
        //method to rotate the list by given positions
        public List<int> RotateList(List<int> list, int positions)
        {
            int count = list.Count;
            positions = positions % count; //handle cases where positions > count
            List<int> rotated = new List<int>();
            //add elements from positions to end
            for (int i = positions; i < count; i++)
            {
                rotated.Add(list[i]);
            }
            //add elements from start to positions
            for (int i = 0; i < positions; i++)
            {
                rotated.Add(list[i]);
            }
            return rotated;
        }
    }
}
