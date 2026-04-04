

using System;
class RocketLaunch2{	
	public static void Main(string[]args){
		//prompt user for input
		int counter = Convert.ToInt32(Console.ReadLine());
		
		for(int i = counter;i>=1;i--){
			Console.WriteLine(i);
		}
	}
}