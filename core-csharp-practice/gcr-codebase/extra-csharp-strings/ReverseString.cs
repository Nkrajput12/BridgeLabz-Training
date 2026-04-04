using System;

class ReverseString
{
    //method for reverse the string without using build in fun.
    public static string Reverse(string str)
    {
        int n = str.Length;
        char[] rev = new char[n];
        for (int i = n-1,j=0; i >= 0; i--,j++) {
            rev[j] = str[i];
        
        }

        return new string(rev);

    }

    //main
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the text:");
        string str = Console.ReadLine();
        if (str == null) return;

        string rev = Reverse(str);

        //print results
        Console.WriteLine("Reverse string is ");
        Console.WriteLine(rev);
    }
}
