using System;
class Power{
	public static void Main(string[]args){
		Console.WriteLine("Enter number");
		int number = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Enter power");
		int power= Convert.ToInt32(Console.ReadLine());
		
		//taking a variable
		int result = 1;
		
		//computing the power using for loop
		for(int i = 0;i<power;i++){
			result *= number;
		}
		
		Console.WriteLine("the result "+result);
	}
}