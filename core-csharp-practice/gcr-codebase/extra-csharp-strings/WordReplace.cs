using System;

class WordReplace
{
    public static void Main(string[]args)
    {
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine() ?? "";

        Console.Write("Word to replace: ");
        string target = Console.ReadLine() ?? "";

        Console.Write("Replacement word: ");
        string replace = Console.ReadLine() ?? "";

        // Call the custom method
        string result = ReplaceWord(sentence, target, replace);

        Console.WriteLine("\nModified Sentence:");
        Console.WriteLine(result);
    }

    //mehtod to replace the old word with new word
    public static string ReplaceWord(string sentence, string old, string newW)
    {
        

        // 1. Split the sentence
        string[] words = sentence.Split(' ');

        // 2. Loop through the array
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == old)
            {
                words[i] = newW;
            }
        }

        
        return string.Join(" ", words);
    }
}