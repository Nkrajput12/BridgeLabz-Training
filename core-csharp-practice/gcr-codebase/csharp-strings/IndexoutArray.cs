using System;

class IndexoutArray
{
    //method to demonstrate index out of bounds exception
    public static void DemoIndexOutArray()
    {
        //initializing an array
        int[] arr = { 1, 2, 3, 4, 5 };
        try
        {
            //accessing an invalid index
            int value = arr[10];
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
        //calling method to demonstrate index out of bounds exception
        DemoIndexOutArray();
    }
}
