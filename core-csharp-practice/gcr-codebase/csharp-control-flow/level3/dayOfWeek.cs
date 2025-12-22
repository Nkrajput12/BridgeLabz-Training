using System;
class DayOfWeek{
    public static void Main(string[] args){
	
		//taking input
        Console.WriteLine("Enter month (1-12):");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter day (1-31):");
        int d = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter year:");
        int y = Convert.ToInt32(Console.ReadLine());
		
		//calculating day of the week
        int y0 = y-(14-m)/12;
        int x = y0+y0/4-y0/100+y0/400;
        int m0 = m+12*((14-m)/12)-2;
        int d0 = (d+x+31*m0/12)%7;

        Console.WriteLine("Day of the week: " + d0);
    }
}