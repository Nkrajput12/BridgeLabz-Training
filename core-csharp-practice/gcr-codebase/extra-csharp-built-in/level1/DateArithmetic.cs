using System;
using System.Globalization;
class DateArithmetic
{
    //method to perform date operations
    static DateTime DateChange(DateTime inputDate)
    {
        
        DateTime updatedDate = inputDate.AddDays(7).AddMonths(1).AddYears(2).AddDays(-21);
        
        return updatedDate;
    }

    static void Main()
    {
        //take teh date input from user
        Console.Write("Enter date (dd-MM-yyyy): ");
        string input = Console.ReadLine()!;
        DateTime date = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        DateTime result = DateChange(date);
        Console.WriteLine("Final Date :" + result.ToString("dd-MM-yyyy"));             
    }
}
