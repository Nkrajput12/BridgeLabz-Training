using System;
 class Weight{
 public static void Main(string[]args){
	//taking weight in pounds
	float weight = Convert.ToSingle(Console.ReadLine());
	
	//converting pounds in kilograms
	double weight_kg = weight*2.2;
	
	Console.WriteLine("The weight of the person in pounds is "+weight+" and in kg is "+weight_kg);
 }}