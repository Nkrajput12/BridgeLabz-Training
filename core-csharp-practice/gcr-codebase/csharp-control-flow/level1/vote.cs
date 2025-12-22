
using System;
class Vote{
	public static void Main(string[]args){
		//prompt the user for input
		Console.WriteLine("Enter age");
		
		//taking user input
		int age = Convert.ToInt32(Console.ReadLine());
		
		//check the person can vote or not
		if(age>=18){
			Console.WriteLine("The person's age is " +age+" and can vote.");
		}
		else{
			Console.WriteLine("The person's age is " +age+" and cannot vote.");
		}
	}
}