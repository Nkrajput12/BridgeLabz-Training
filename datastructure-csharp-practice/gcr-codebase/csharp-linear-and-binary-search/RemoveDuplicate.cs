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
            RemoveDuplicate obj = new RemoveDuplicate();

            Console.Write("Enter String: ");
            string str = Console.ReadLine();

            string remove = obj.Remove(str);

            Console.WriteLine("String after Remove Duplicate: " + remove);
        }

        //method to remove the duplicate
        public string Remove(string str)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                char currentchar = str[i];
                bool alreadyExists = false;

                // Check if our StringBuilder already contains this character
                for (int j = 0; j < sb.Length; j++)
                {
                    if (sb[j] == currentchar)
                    {
                        alreadyExists = true;
                        break;
                    }
                }

                // Only append if it wasn't found
                if (!alreadyExists)
                {
                    sb.Append(currentchar);
                }
            }

            return sb.ToString();
        }
    }
}
