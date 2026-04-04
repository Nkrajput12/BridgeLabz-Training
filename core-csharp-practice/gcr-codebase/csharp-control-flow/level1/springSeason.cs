
using System;
class SpringSeason{
	public static void Main(string[]args){
		//prompt user for input
		Console.WriteLine("Enter month and day respectively in numbers");
		
		//taking input
		int month = Convert.ToInt32(Console.ReadLine());
		int day = Convert.ToInt32(Console.ReadLine());
		
		//check it is spring season or not by using if-else
		if((month == 3 && day >= 20 && day <= 31) || (month == 4 && day >= 1  && day <= 30) || (month == 5 && day >= 1  && day <= 31) || (month == 6 && day >= 1  && day <= 20)){
			Console.WriteLine("Its a Spring Season");
		}
		else {
			Console.WriteLine("Not a Spring Season");
		}
                         	
		
	}
}