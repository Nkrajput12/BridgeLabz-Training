using System;

class TexttoUpper
{

    //method to convert text to uppercase by char manipulation
    public static string ConvertToUpper(string input)
    {
        char[] charArray = input.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            if (charArray[i] >= 'a' && charArray[i] <= 'z')
            {
                charArray[i] = (char)(charArray[i] - 'a' + 'A');
            }
        }
        return new string(charArray);
    }


    public static void Main(string[]args)
    {
        //taking input from user
        Console.WriteLine("Enter text");
        string input = Console.ReadLine();

        
        string uppercasebuild = input.ToUpper();//by built in method
        string uppercasemanuual = ConvertToUpper(input);


        Console.WriteLine("by built in method = " + uppercasebuild);
        Console.WriteLine("by char manipulation = " + uppercasemanuual);

        //compare
        bool result = uppercasemanuual.Equals(uppercasebuild);
        if (result) Console.WriteLine("both strings are equal");
        else Console.WriteLine("both strings are not equal");       
    }
}