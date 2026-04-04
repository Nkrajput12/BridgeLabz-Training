using System;

class Indexout
{
    //method to demonstrate index out of range exception
    public static void DemoIndexOut()
    {
        //initializing a string
        string str = "Hello, World!";
        try
        {
            //accessing an invalid index
            char ch = str[20];
        }
        catch (IndexOutOfRangeException ex)
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
        //calling method to demonstrate index out of range exception
        DemoIndexOut();
    }
}
