using System;
class PalindromeString
{
    //checking for palindrome
    public static bool IsPalindrome(string str)
    {
        char[] rev1 = str.ToCharArray();
        Array.Reverse(rev1);
        string rev = new String(rev1);

        if (rev.Equals(str)) return true;
        else return false;

    }

    //method for display the result
    public static void Display(bool b)
    {
        if (b) Console.WriteLine("Palindrome string");
        else Console.WriteLine("Not a Palindrome string");
    }

    //main method 
    public static void Main(string[] args)
    {
        //taking input 
        Console.WriteLine("enter the string:");
        string str = Console.ReadLine() ?? "";

        bool result = IsPalindrome(str);

        Display(result);

    }
}
  
