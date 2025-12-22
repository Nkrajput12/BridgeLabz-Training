
using System;
 class NaturalNumber{
	public static void Main(string[]args){
		//prompt the user for input
		Console.WriteLine("Enter a number");
		//taking user input
		int num = Convert.ToInt32(Console.ReadLine());
		
		//check if the number is natural number or not
		if(num>0){
			// calculating the sum of  n natural number
			int sum = num*(num+1)/2;
			
			Console.WriteLine("The sum of "+num+" natural numbers is "+sum);
		}
		else{
			Console.WriteLine("The number "+num+" is not a natural number");
		}
	}
 }