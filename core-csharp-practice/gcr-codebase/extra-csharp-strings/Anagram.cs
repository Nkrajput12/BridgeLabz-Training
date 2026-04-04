using System;
class AnagramCheck
{
    punlic static void Main(string[]args)
    {
        Console.Write("Enter the first string: ");
        string s1 = Console.ReadLine() ?? "";

        Console.Write("Enter the second string: ");
        string s2 = Console.ReadLine() ?? "";

        // Call the separate method
        if (AreAnagrams(s1, s2))
        {
            Console.WriteLine($"\"{s1}\" and \"{s2}\" are anagrams.");
        }
        else
        {
            Console.WriteLine($"\"{s1}\" and \"{s2}\" are NOT anagrams.");
        }
    }

   
    /// method to checks if two strings are anagrams by sorting them.
   
    public static bool AreAnagrams(string str1, string str2)
    {
        // Clean the strings: remove spaces and convert to lowercase
        string clean1 = str1.Replace(" ", "").ToLower();
        string clean2 = str2.Replace(" ", "").ToLower();

        // If lengths are different, they cannot be anagrams
        if (clean1.Length != clean2.Length)
        {
            return false;
        }

        
        char[] arr1 = clean1.ToCharArray();
        char[] arr2 = clean2.ToCharArray();

        Array.Sort(arr1);
        Array.Sort(arr2);

        // Compare the sorted arrays
        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
            {
                return false;
            }
        }

        return true;
    }
}