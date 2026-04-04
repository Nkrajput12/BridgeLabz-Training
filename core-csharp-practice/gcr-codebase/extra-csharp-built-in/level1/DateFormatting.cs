using System;
class DateFormatting
{
    //method to print date in different formats
    static void Display(DateTime date)
    {
        Console.WriteLine("Format (dd/MM/yyyy): " + date.ToString("dd/MM/yyyy"));
        Console.WriteLine("Format (yyyy-MM-dd): " + date.ToString("yyyy-MM-dd"));
        Console.WriteLine("Format (EEE, MMM dd, yyyy): " + date.ToString("ddd, MMM dd, yyyy"));
    }
    static void Main()
    {
        DateTime Date = DateTime.Now;
        //method call
        Display(Date);
    }
}