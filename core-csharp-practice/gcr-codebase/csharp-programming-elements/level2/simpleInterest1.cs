using System;
 class Simpleinterest{
 public static void Main(string[]args){
	//taking principal, rate and time
	float principal = Convert.ToSingle(Console.ReadLine());
	float rate = Convert.ToSingle(Console.ReadLine());
	float time = Convert.ToSingle(Console.ReadLine());
	
	//calculating simple interest
	float simple_interest = (principal*rate*time)/100;
	
	Console.WriteLine("The Simple Interest is "+simple_interest+" for Principal "+principal+", Rate of Interest "+rate+" and Time "+time);
 }
 }