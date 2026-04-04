using System;
class Abundant{
	public static void Main(string[] args){
		Console.WriteLine("Enter a number");
		int number = Convert.ToInt32(Console.ReadLine());
		int sum = 0;
		for (int i = 1; i < number; i++){
			if (number % i == 0){
				sum += i;
			}
		}
		if (sum > number){
			Console.WriteLine("Abundant Number");
		}
		else{
			Console.WriteLine("Not an Abundant Number");
		}
	}
}