using System;
class Leapyear2{
    public static void Main(string[]args) {
        Console.WriteLine("Enter a year");
        int year = Convert.ToInt32(Console.ReadLine());
        if (year < 1582) {
            Console.WriteLine("The Gregorian calendar only started in 1582.");
        }else if ((year%4==0 && year%100!=0) || (year%400==0)) {
            Console.WriteLine(year + " is a Leap Year");
        } else {
            Console.WriteLine(year + " is not a Leap Year");
        }
    }
}