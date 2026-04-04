using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_linear_and_binary_search
{
    internal class SearchWord
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("enter the number of Sentences: ");
            int n = int.Parse(Console.ReadLine());

            string[] str = new string[n];
            Console.WriteLine("Enter sentences");
            for (int i = 0; i < n; i++)
            {
                Console.Write("index no " + i + ":");
                str[i] = Console.ReadLine();
            }

            Console.WriteLine("Enter the word you want to search");
            string word = Console.ReadLine();

            SearchWord search = new SearchWord();
            string str1 = search.Searchword(str,word);
            if (str1 == null)
            {
                Console.WriteLine("there is not a single Sentance contains the specific word");
            }
            else
            {
                Console.WriteLine("The first sentance contain that word is:  " + str1);
            }
        }

        //method for lenear search the first negative number
        public string Searchword(string[] str,string Word)
        {

            for (int i = 0; i < str.Length; i++)
            {

                if (str[i].ToLower().Contains(Word))
                {
                    return str[i];
                }
            }


            return null;
        }

    }
}


