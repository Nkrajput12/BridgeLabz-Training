
using System;
class Checksmall{
	public static void Main(string[]args){
		//prompt the user for input
		Console.WriteLine("Enter three numbers");
		//taking input
		int num1 = Convert.ToInt32(Console.ReadLine());
		int num2 = Convert.ToInt32(Console.ReadLine());
		int num3 = Convert.ToInt32(Console.ReadLine());
		
		//writing logic using control flow to check if the first number is smallest or not
		if(num1 < num2 && num1<num3){
			Console.WriteLine("Is the first number the smallest? Yes");
		}
		else {
			Console.WriteLine("Is the first number the smallest? No");
		}
	}
}