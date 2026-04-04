using System;

class ParagraphAnalyzer
{
    //method to count words and display the words length in the string
    public static void CountWords(string str)
    {
        string[] word = str.Split(' ');

        Console.WriteLine("The number of words in the paragraph is = "+word.Length);
    }

    //method to find and display the longest word{
    public static void DisplayLongestWord(string str)
    {
        string[] word = str.Split(' ');
        string LongestWord = "";
        for (int i = 0; i < word.Length; i++)
        {
            if (LongestWord.Length < word[i].Length) //if the longestword lenght is less than word[i] lenght 
            {
                LongestWord = word[i]; // assign the word[i] to Longest word
            }
        }

        Console.WriteLine("the Longest word in the string is: \"" + LongestWord + "\"");
    }


    //method to replace a specific word with another word and display the updated para:
    public static void Replace(string text)
    {   //
        //taking the word want to replace.
        Console.WriteLine("enter the word you want to replace:");
        string old = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the word you want to replace the word with:");
        string new1 = Console.ReadLine() ?? "";

        string[] words = text.Split(' ');
        for (int i = 0;i < words.Length;i++)
        {
            if (words[i] == old) //check if word equal to word word user want to replace or not
            {
                words[i] = new1; //replace the old word with new.
            }
        }

        string str =  string.Join(" ", words); //convert string array to string and join them by " "

        Console.WriteLine(str);
    }

    //method for choice and display
    public static void Choice(string text)
    { 
        //loop for choices selection
        while (true) {
            Console.WriteLine(" press 1 to count number of words: \t press 2 to display the Longest word: \t press 3 to replace words1: \t press 4 for Exit:");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n) //use to call method according to choices
            {
                case 1: 
                    CountWords(text); 
                    break;

                case 2:
                    DisplayLongestWord(text);
                    break;

                case 3:
                    
                    Replace(text);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default: //if user enter invalid choice ask them to again enter the choice

                    Console.WriteLine("please enter the right choice"); 
                    break;

            }
        }
    } 

    
    

    //main method
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("enter text:");
        string text = Console.ReadLine() ?? "";
        if(string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Empty string  or string with only spaces not acceptable:");
            Environment.Exit(0);
        }
        
       

        Choice(text);
    }
        

}

