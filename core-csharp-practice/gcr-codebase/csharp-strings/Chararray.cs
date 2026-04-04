using System;

public class Chararray
{
    //method to convert string to char array without using ToCharArray()
    static char[] StrToArray(string str)
    {
        char[] arr = new char[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            arr[i] = str[i];
        }
        return arr;
    }



    //method to compare two char arrays
    static bool Compare(char[] arr1, char[] arr2)
    {
        if (arr1.Length != arr2.Length)
            return false;
        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
                return false;
        }
        return true;
    }

    public static void Main()
    {
        //taking input from user
        Console.WriteLine("Enter a string:");
        string str = Console.ReadLine();

        char[] arr1 = StrToArray(str); //whithod ToCharArray()
        char[] arr2 = str.ToCharArray();


        //comparing both arrays
        bool equal = Compare(arr1, arr2);

        if (equal)
        {
            Console.WriteLine("Both char arrays are equal.");
        }
        else
        {
            Console.WriteLine("Char arrays are not equal.");
        }


    }

}
