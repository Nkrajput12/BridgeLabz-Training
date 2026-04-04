
using System;
 class Vol{
  public static void Main(string[]args){
	double radius = 6378.0;
	double radius_miles = radius/1.6;
	
	double vol_km = (4.0/3.0)*3.14*radius*radius*radius;
	
	double vol_mil = (4.0/3.0)*3.14*radius_miles*radius_miles*radius_miles;
	
	Console.WriteLine("The volume of earth in cubic kilometers is " + vol_km + " and cubic miles is " + vol_mil);
  }
 }