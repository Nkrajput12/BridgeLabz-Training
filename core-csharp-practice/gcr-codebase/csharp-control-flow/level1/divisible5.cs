
using System;
class Divisible5{
	public static void Main(string[]args){
		//prompt the user for input
		Console.WriteLine("Enter a number");
		//taking user input
		int num = Convert.ToInt32(Console.ReadLine());
	
		//Check if the number is divisible by 5 or not
		if(num%5==0) Console.WriteLine("Is the number "+num+" divisible by 5? Yes");
		else Console.WriteLine("Is the number "+num+" divisible by 5? No");

}

}
