using System;

class Argumentout
{
    //method to demonstrate argument out of range exception
    public static void DemoArgumentOut()
    {
        //initializing a string
        string str = "Hello, World!";
        try
        {
            //using an invalid start index for substring
            string substr = str.Substring(5, 20);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Caught an exception!!");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("exception handled");
        }
    }
    public static void Main()
    {
        //calling method to demonstrate argument out of range exception
        DemoArgumentOut();
    }
}
