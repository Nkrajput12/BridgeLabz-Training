
using System;
class PosNegZero{
 public static void Main(string[]args){
	//prompt the user for input
	Console.WriteLine("Enter a number");
	
	//taking inputs
	int num = Convert.ToInt32(Console.ReadLine());
	
	//check whether the number is positive,negative or zero
	if(num>0){
		Console.WriteLine("positive");
	}
	else if(num == 0){
		Console.WriteLine("zero");
		
	}
	else{
		Console.WriteLine("negative");
	}
	
 }
}