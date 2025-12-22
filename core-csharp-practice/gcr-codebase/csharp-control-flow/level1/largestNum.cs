
using System;
class LargestNum{
	public static void Main(string[]args){
		//prompt the user for input
		Console.WriteLine("Enter three numbers");
		//taking input
		int num1 = Convert.ToInt32(Console.ReadLine());
		int num2 = Convert.ToInt32(Console.ReadLine());
		int num3 = Convert.ToInt32(Console.ReadLine());
		//find who is largest
		bool first = (num1 > num2 && num1 > num3);
		bool second = (num2 > num1 && num2 > num3);
		bool third = (num3 > num2 && num3 > num1);
		
		Console.WriteLine("Is the first number the largest? "+first);
		Console.WriteLine("Is the second number the largest? "+second);
		Console.WriteLine("Is the third number the largest? "+third);
		
	}
}