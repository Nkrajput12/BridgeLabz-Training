using System;
class Calender
{
    //method to get month name from month number
    public static string GetMonthName(int monthNumber)
    {
        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        if (monthNumber < 1 || monthNumber > 12)
        {
            return "Invalid month number";
        }
        return months[monthNumber - 1];
    }

    //method to get number of days in a month
    public static int GetDaysInMonth(int monthNumber, int year)
    {
        if (monthNumber < 1 || monthNumber > 12)
        {
            return -1; // Invalid month number
        }
        if (monthNumber == 2)
        {
            // Check for leap year
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                return 29;
            }
            else
            {
                return 28;
            }
        }
        int[] daysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        return daysInMonths[monthNumber - 1];
    }

    //method to get the first day of the month
  
    public static int GetFirstDay(int month, int year)
    {
        int m = month;
        int y = year;
        int y0 = y - (14 - m) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        int d0 = (1 + x + 31 * m0 / 12) % 7;
        return d0;
    }

    //method to display calender
    public static void DisplayCalendar(int month, int year)
    {
        Console.WriteLine("   " + GetMonthName(month) + " " + year);
        Console.WriteLine("Su Mo Tu We Th Fr Sa");

        int firstDay = GetFirstDay(month, year);
        int days = GetDaysInMonth(month, year);

        for (int i = 0; i < firstDay; i++)
        {
            Console.Write("   ");
        }

        //print days
        for (int day = 1; day <= days; day++)
        {
            Console.Write(day.ToString().PadLeft(2) + " ");
            if ((day + firstDay) % 7 == 0)
                Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void Main(string[]args)
    {
        Console.Write("Enter month (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        DisplayCalendar(month, year);
    }
}