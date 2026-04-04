using System;

class ConsonantVowel
{
    //method to count vowel and consonent
    public static int[] Count(string value)
    {
        int vowelCount = 0;
        int ConsonantCount = 0;
        string val = value.ToLower();
        for(int i = 0; i < value.Length; i++)
        {
            char c = val[i];
            if(c == 'a' || c == 'e' || c=='i' || c=='o' || c == 'u')
            {
                vowelCount++;
            }
            else if( c != ' ')
            {
                ConsonantCount++;
            }
        }

        return new int[] { vowelCount, ConsonantCount };
    }

    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("enter the text");
        string str = Console.ReadLine();

        int[] count = Count(str);

        Console.WriteLine("Number of vowels = " + count[0]);
        Console.WriteLine("Number of consonant = " + count[1]);

    }
}
