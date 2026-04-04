
using System;
class RocketLaunch{	
	public static void Main(string[]args){
		//prompt user for input
		int counter = Convert.ToInt32(Console.ReadLine());
		
		while(counter>=1){
			Console.WriteLine(counter);
			counter--;
		}
	}
}