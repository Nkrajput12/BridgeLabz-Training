using System;
class SpringSeason
{
    //method to check if the month is in spring season
    public static bool IsSpringMonth(int month, int day)
    {
        if ((month == 3 && day >= 20 && day <= 31) || (month == 4 && day >= 1 && day <= 30) || (month == 5 && day >= 1 && day <= 31) || (month == 6 && day >= 1 && day <= 20))
        {
            Console.WriteLine("True");
            return true;
        }
        else
        {
            Console.WriteLine("False");
            return false;
        }
    }
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter a month");
        int month = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter a day");
        int day = Convert.ToInt32(Console.ReadLine());

        //call method
        bool isSpring = IsSpringMonth(month,day);

        if(isSpring)
        {
            Console.WriteLine("spring season");
        }
        else
        {
            Console.WriteLine("not a spring season");
        }

    }
}
