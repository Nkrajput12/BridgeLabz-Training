using System;
class BMI{
 public static void Main(string[]args){
	//taking input
	Console.WriteLine("Enter yout weight in kg");
	double weight = Convert.ToDouble(Console.ReadLine());
	
	Console.WriteLine("Enter yout height in cm");
	double height = Convert.ToDouble(Console.ReadLine());
	//convert cm into meter
	double height_meter = height/100;
	
	//calculate BMI
	double bmi = weight/(height_meter*height_meter);
	
	if(bmi<=18.4) Console.WriteLine("Underweight");
	else if(bmi >18.4 && bmi<25) Console.WriteLine("Normal");
	else if(bmi >=25 && bmi<39.9) Console.WriteLine("Overweight");
	else Console.WriteLine("Obese");
	
 }
 
 }