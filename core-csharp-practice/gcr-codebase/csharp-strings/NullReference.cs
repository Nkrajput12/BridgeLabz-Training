using System;

class NullReference
{
    //method to demonstrate null reference exception
    public static void DemoNull()
    {
        //initializing a null string
        string str = null;
        try
        {
            
            int length = str.Length;
        }
        catch (NullReferenceException ex)
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
        //calling method to demonstrate null reference exception
        DemoNull();
    }
}

