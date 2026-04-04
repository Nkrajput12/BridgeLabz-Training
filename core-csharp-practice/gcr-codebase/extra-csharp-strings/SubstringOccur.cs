using System;

class SubstringOccur
{
    // Method for calculating the occurrence of substring
    public static int Occur(string str, string substring)
    {
        int count = 0;
        for (int i = 0; i <= str.Length - substring.Length; i++)
        {
            int match = 0;
            for (int j = 0; j < substring.Length; j++)
            {
                if (str[i + j] == substring[j])
                {
                    match++;
                }
            }

            if (match == substring.Length)
            {
                count++;
            }
        }

        return count; 
    }

    public static void Main(string[] args)
    {   
        //taking user input 
        Console.WriteLine("Enter the text:");
        string text = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the substring:");
        string sub = Console.ReadLine() ?? "";
        //call method 
        int result = Occur(text, sub);

        //print the results
        Console.WriteLine($"The substring '{sub}' appears {result} times.");
    }
}