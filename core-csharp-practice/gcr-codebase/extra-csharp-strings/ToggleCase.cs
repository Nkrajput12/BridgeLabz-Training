using System;
class ToggleCase
{
    public static string Toggle(string input)
    { 
        char[] result = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];
            result[i] = char.IsUpper(ch) ? char.ToLower(ch) : char.IsLower(ch) ? char.ToUpper(ch) : ch;
        }
        return new string(result);
    }

    public static void Main(string[] args)
    {
        //take the string input from user
        Console.WriteLine("Enter a text:");
        string input = Console.ReadLine() ?? "";

        string result = Toggle(input);
        Console.WriteLine("string after Toggle case = "+result);



    }
}