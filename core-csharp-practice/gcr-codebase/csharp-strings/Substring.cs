using System;

class Substring
{
    //method to get substring from a string
    static string Getsub(string str, int start, int end)
    {
        string result = str.Substring(start, end - start + 1);
        return result;  
    }

    public static void Main()
    {
        //taking input from user
        Console.WriteLine("Enter a string:");
        string str = Console.ReadLine();
        Console.WriteLine("Enter start index:");
        int start = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter end index:");
        int end = Convert.ToInt32(Console.ReadLine());
        
        
        //calling method to get substring
        string result = Getsub(str, start, end);


        Console.WriteLine("The substring is: " + result);


        //compare result
        if (str.Contains(result))
        {
            Console.WriteLine("The substring is in the original string");
        }
        else
        {
            Console.WriteLine("The substring is not in the original string");
        }


    }
}
