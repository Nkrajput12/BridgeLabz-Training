using System;
class TimeZone
{
    //method to display current time in time zone
    public static  void ShowTimeZone()
    {
        DateTimeOffset gmt = DateTimeOffset.UtcNow;
        TimeZoneInfo ist = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        //printing time in gmt,ist & pst
        Console.WriteLine("GMT TimeZone: " + gmt);
        Console.WriteLine("IST TimeZone: " + TimeZoneInfo.ConvertTime(gmt, ist));
        Console.WriteLine("PST TimeZone: " + TimeZoneInfo.ConvertTime(gmt, pst));
    }

    public static void Main(string[] args)
    {
        ShowTimeZone();
    }
}