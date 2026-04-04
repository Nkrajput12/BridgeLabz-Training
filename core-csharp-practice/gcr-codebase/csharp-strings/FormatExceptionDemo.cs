using System;

class FormatExceptionDemo
{
    //method to demonstrate format exception
    public static void DemoFormatException()
    {
        //initializing an invalid number string
        string str  = "abc";
        try
        {
            //attempting to store the char in an integer variable
            int num = Convert.ToInt32(str);
        }
        catch (FormatException ex)
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
        //calling method to demonstrate format exception
        DemoFormatException();
    }
}