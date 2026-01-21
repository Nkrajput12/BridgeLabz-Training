//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraining.access
//{
//    internal class FrequencyFinder
//    {
//        public static void Main(string[] args)
//        {
//            FrequencyFinder finder = new FrequencyFinder(); //creating object for FrequencyFinder class
//            Console.WriteLine("Enter the elements (comma separated):");
//            string[] input = Console.ReadLine().Split(','); //input from user split by comma
//            //trimming spaces from each element and store in a list
//            List<string> thing = new List<string>();
//            foreach (string num in input)
//            {
//                thing.Add(num.Trim());
//            }

//            //finding frequency of each element
//            Dictionary<string, int> frequency = finder.FindFrequency(thing);
//using System;
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
//print results
//            Console.WriteLine("Element Frequencies:");
//            foreach (var pair in frequency)
//            {
//                Console.WriteLine($"{pair.Key}: {pair.Value}");
//            }

//        }

//        //method to count the frequency of each element in the list
//        public Dictionary<string, int> FindFrequency(List<string> elements)
//        {
//            //using dictionary to store frequency of each element
//            Dictionary<string, int> frequencyMap = new Dictionary<string, int>();
//            foreach (string element in elements)
//            {
//                //check if element already exists in dictionary
//                if (frequencyMap.ContainsKey(element))
//                {
//                    frequencyMap[element]++; //if exists, increment its frequency by 1
//                }
//                else //if not exists, add it with frequency 1
//                {
//                    frequencyMap[element] = 1;//initialize frequency to 1
//                }
//            }
//            return frequencyMap; 
//        }
//    }
//}
