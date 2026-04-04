using System.Text;

namespace BridgeLabzTraining
{
    internal class LexicalTwist
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the first word");
            string firstWord = Console.ReadLine();
            if(firstWord.Contains(" "))
            {
                Console.WriteLine(firstWord + " is an invalid word");
                return;
            }

            Console.WriteLine("Enter the second word");
            string secondWord = Console.ReadLine();
            if (firstWord.Contains(" "))
            {
                Console.WriteLine(secondWord + " is an invalid word");
                return;
            }


            LexicalTwist lexical = new LexicalTwist();
            if (lexical.CheckForReverse(firstWord, secondWord))
            {
                lexical.IsReverse(firstWord, secondWord);
            }
            else
            {
                lexical.IsNotReverse(firstWord, secondWord);
            }
        }

        public bool CheckForReverse(string firstWord, string secondWord)
        {
            char[] rev = firstWord.ToCharArray();
            Array.Reverse(rev);
            string reverse = new string(rev);
            


            if (reverse.ToLower().Equals(secondWord.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IsReverse(string firstWord , string secondWord)
        {
            StringBuilder sb = new StringBuilder();
            string word = secondWord.ToLower();

            for(int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
                {
                    sb.Append("@");
                    
                }
                else
                {
                    sb.Append(word[i]);
                }
            }

            Console.WriteLine(sb.ToString());
        }

        public void IsNotReverse(string firstWord, string secondWord)
        {
            StringBuilder sb = new StringBuilder(firstWord);
            sb.Append(secondWord);

            string word = sb.ToString().ToUpper();
            
            int vowels = 0;
            int consonents = 0;

            for(int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'A' || word[i] == 'E' || word[i] == 'I' || word[i] == 'O' || word[i] == 'U')
                {
                    vowels++;
                }
                else
                {
                    consonents++;
                }
            }

            if(vowels > consonents)
            {
                string print = "";
                int count = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == 'A' || word[i] == 'E' || word[i] == 'I' || word[i] == 'O' || word[i] == 'U')
                    {
                        if (!(print.Contains(word[i])))
                        {
                            Console.Write(word[i]);
                            count++;
                        }

                        if (count >= 2)
                        {
                            return;
                        }
                        print += word[i];
                    }
                }
            }
            else if(consonents > vowels)
            {
                string print = "";
                int count = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (!(word[i] == 'A' || word[i] == 'E' || word[i] == 'I' || word[i] == 'O' || word[i] == 'U'))
                    {

                        if (!(print.Contains(word[i])))
                        {
                            Console.Write(word[i]);
                            count++;
                        }
                        
                        if (count >= 2)
                        {
                            return;
                        }
                        print += word[i];
                    }
                }
            }
            else
            {
                Console.WriteLine("Vowels and Consonants are equal");
            }

        }
    }
}
