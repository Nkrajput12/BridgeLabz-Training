using System;

class LongestWord
{
    //mehtod for finding the longest word
    public static string Longest(string sentence)
    {
       
        
        string[] words = sentence.Split(' ');

        string longestWord = "";

        foreach (string word in words)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;

            }
        }

        return longestWord;
    }

    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the text");
        string text = Console.ReadLine() ?? "";

        //call method
        string large = Longest(text);

        Console.WriteLine("the Longest word is \"" + large + "\"");

    }
}
