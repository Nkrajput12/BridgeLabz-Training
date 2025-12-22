
using System;
class DistanceConv{
 public static void Main(string[]args){
  float distance_feet = Convert.ToSingle(Console.ReadLine());   //taking input in feet
  //calculating the distance in yards and miles
  float distance_yards = distance_feet/3;
  float distance_miles = distance_yards/1760;
  
  Console.WriteLine("your Distace in feet is "+distance_feet+" while in yards is "+distance_yards+" and miles is "+distance_miles);
  
  
  
 }
}