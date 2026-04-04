using System;
class Calculator{
	public static void Main(string[] args){
		
		//taking input
		Console.WriteLine("Enter first number:");
		double first = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter second number:");
		double second = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter operator (+, -, *, /):");
		string op = Console.ReadLine();
		
		//use switch case to perform the operation
		switch (op){
			case "+":
			Console.WriteLine(first + second);
			break;

			case "-":
			Console.WriteLine(first - second);
			break;

			case "*":
			Console.WriteLine(first * second);
			break;

			case "/":
			if (second != 0){
				Console.WriteLine(first / second);
			}
			else{
				Console.WriteLine("Cannot divide by zero");
			}
			break;

			default:
			Console.WriteLine("Invalid Operator");
			break;
		}
	}
}