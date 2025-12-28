using System;

class RemoveDuplicate
{
    //mehtod for removing duplicate elements
    public static string Remove(string str)
    {
        string result = "";
        //loop for store unique element in result string
        foreach (char ch in str)
        {
            if (!result.Contains(ch))
            {
                result += ch;
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        //taking input from usr
        Console.WriteLine("enter text");
        string text = Console.ReadLine() ?? "";

        //calling method
        string result = Remove(text);

        Console.WriteLine("string after removing duplicate = "+result);
    }
}