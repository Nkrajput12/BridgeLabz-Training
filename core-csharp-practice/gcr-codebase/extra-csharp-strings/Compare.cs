using System;

class Compare
{
    public static void Main(string[]args)
    {
        // 1. Take inputs from the user
        Console.Write("Enter first string: ");
        string s1 = Console.ReadLine() ?? "";

        Console.Write("Enter second string: ");
        string s2 = Console.ReadLine() ?? "";

        // 2. Calmethod
        int result = CompareLexi(s1, s2);

        // 3. Output the result
        if (result < 0)
        {
            Console.WriteLine("First string comes first.");
        }
        else if (result > 0)
        {
            Console.WriteLine("Second string comes first.");
        }
        else
        {
            Console.WriteLine("The strings are equal.");
        }
    }

    
    public static int CompareLexi(string str1, string str2)
    {
        int minLen = Math.Min(str1.Length, str2.Length);

        
        for (int i = 0; i < minLen; i++)
        {
            if (str1[i] != str2[i])
            {
                // Return the difference in character values
                return str1[i] - str2[i];
            }
        }

        // If characters are identical up to minLen, the shorter string comes first
        return str1.Length - str2.Length;
    }
}