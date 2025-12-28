using System;

public class RemoveChar
{
    //method for removing the character from string
    public static string Remove(string str , char c)
    {
        string result = "";
        
        foreach (char ch in str)
        {
            if (ch != c)
            {
                result += ch;
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        //taking input 
        Console.Write("Enter the text: ");
        string str = Console.ReadLine() ?? "";
        Console.Write("Enter the character you want to remove: ");
        char c = Convert.ToChar(Console.ReadLine());

        //call method
        string result = Remove(str , c);

        Console.WriteLine("result = " + result);
    }
}
