
using System;
class NumberOfDigit{
	public static void Main(string[]args){
		//taking input
		Console.WriteLine("enter a number");
		int number = Convert.ToInt32(Console.ReadLine());
		
		int count = 0;
		
		while(number !=0){
			count++;
			number = number/10;
		}
		
		Console.WriteLine("the number of digit in number is "+count);
	}
}