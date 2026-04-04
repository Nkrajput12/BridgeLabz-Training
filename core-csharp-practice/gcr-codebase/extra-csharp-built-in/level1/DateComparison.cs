using System;
using System.Globalization;
class DateComparison
{
    public static void Date(DateTime firstDate, DateTime secondDate)
    {
        if (firstDate < secondDate)
        {
            Console.WriteLine("1st date is before 2nd date");
        }
        else if (firstDate > secondDate)
        {
            Console.WriteLine("1st date is after 2nd date");
        }
        else
        {
            Console.WriteLine("Both dates are the same");
        }
    }

    public static void Main(string[]args)
    {
        //taking input from user
        Console.Write("Enter first date (dd-MM-yyyy): ");
        string input1 = Console.ReadLine()!; //first date
        Console.Write("Enter second date (dd-MM-yyyy): ");
        string input2 = Console.ReadLine()!; //second date


        DateTime date1 = DateTime.ParseExact(input1, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(input2, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        Date(date1, date2);
    }
}
