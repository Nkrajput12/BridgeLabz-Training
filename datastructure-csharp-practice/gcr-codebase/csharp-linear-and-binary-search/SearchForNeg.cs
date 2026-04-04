using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_linear_and_binary_search
{
    internal class SearchForNeg
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("enter the number of elements: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            Console.WriteLine("Enter elements");
            for(int i = 0; i < n; i++)
            {
                Console.Write("index no " + i+":");
                arr[i] = int.Parse(Console.ReadLine());
            }

            SearchForNeg search = new SearchForNeg();
            int num = search.SearchNeg(arr);
            if(num == 0)
            {
                Console.WriteLine("there is not a single negative number");
            }
            else
            {
                Console.WriteLine("The first Negative number is " + num);
            }
        }

        //method for lenear search the first negative number
        public int SearchNeg(int[] arr)
        {
            
            for (int i = 0; i < arr.Length; i++)
            {
                
                if (arr[i] < 0)
                {
                    return arr[i];
                }
            }

            
            return 0;
        }
    
    }
}

