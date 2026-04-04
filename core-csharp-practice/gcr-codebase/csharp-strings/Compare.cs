using System;
class Compare
{
    static void Main()
    {
        //taking input from user
        Console.WriteLine("Enter first string:");
        string str1 = Console.ReadLine();
        Console.WriteLine("Enter second string:");
        string str2 = Console.ReadLine();

        //calling method to compare strings
        bool equal = CompareStrings(str1, str2);

        bool user = CompareStrings(str1, str2);
        bool built = str1.Equals(str2);
        
        if(user == built)
        {
            Console.WriteLine("Both methods agree.");
        }
        else
        {
            Console.WriteLine("Methods disagree.");
        }
    }

    //method to compare two strings
    static bool CompareStrings(string s1, string s2)
    {
        int flag = 0;

        for(int i = 0; i < s1.Length && i < s2.Length; i++)
        {
            if (!s1[i].Equals(s2[i]))
            {
                flag = 1;
                break;
            }
        }


        if (flag == 1 || s1.Length != s2.Length)
            return false;
        else
            return true;


    }
}