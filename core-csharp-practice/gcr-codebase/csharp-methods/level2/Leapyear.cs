using System;
class LeapYear
{
    static bool Leapyear(int year)
    {
        if (year < 1582) return false;
        else if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void Main()
    {
        //takeing input from user
        Console.Write("Enter year");
        int year = Convert.ToInt32(Console.ReadLine());

        //call method and check for leap year
        if (Leapyear(year))
            Console.WriteLine("Leap Year");
        else
            Console.WriteLine("Not a Leap Year");
    }
}