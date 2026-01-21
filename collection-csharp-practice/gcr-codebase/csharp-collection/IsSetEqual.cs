//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraining.access
//{
//    internal class IsSetEqual
//    {
//        public static void Main(string[] args)
//        {
//            IsSetEqual isSetEqual = new IsSetEqual(); //create instance of IsSetEqual class
//            Console.WriteLine("Enter elements of first set (comma separated):"); //user input
//            string[] input1 = Console.ReadLine().Split(','); //read user input

//            Console.WriteLine("Enter elements of second set (comma separated):"); //user input
//            string[] input2 = Console.ReadLine().Split(','); //read user input

//            //strore the elements in HashSet
//            HashSet<string> set1 = new HashSet<string>(input1);
//            HashSet<string> set2 = new HashSet<string>(input2);

//            bool Isequal = isSetEqual.AreSetsEqual(set1, set2); //call AreSetsEqual method
//            if(Isequal)
//            {
//                Console.WriteLine("The two sets are equal.");
//            }
//            else
//            {
//                Console.WriteLine("The two sets are not equal.");
//            }

//        }

//        //method to check if two sets are equal
//        public bool AreSetsEqual<T>(HashSet<T> set1, HashSet<T> set2)
//        {
//            return set1.SetEquals(set2);
//        }
//    }
//}
