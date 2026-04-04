
using System;
class Harshad{
	public static void Main(string[]args){
		//taking input
		Console.WriteLine("Enter a number");
		int number = Convert.ToInt32(Console.ReadLine());
		
		int temp = number;
		int sum = 0,rem=0;
		
		//calculating the sum of digits
		while(temp>0){
			rem = temp%10;
			sum += rem;
			temp /= 10;
		}
		
		if(number%sum == 0){
			Console.WriteLine("it is a Harshad Number");
		}
		else{
			Console.WriteLine("it is not a Harshad Number");
		}
	}
}