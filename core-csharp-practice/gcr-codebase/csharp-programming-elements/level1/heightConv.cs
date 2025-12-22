
using System;
class Heightconversion{
 public static void Main(string[]args){
	double height = Convert.ToDouble(Console.ReadLine()); //taking height in cm as input
	
	double foot = height/30.48; //calculating height in feet
	
	double inches = height/2.54;//calculating height in inches
	
	Console.WriteLine("Your Height in cm is " + height+ " while in feet is " + foot + " and inches is " + inches);
 }
}