
using System;
class Side{
 public static void Main(String[]args){
  double perimeter = Convert.ToDouble(Console.ReadLine()); //taking input
  // calculating the side of the square 
  double side = perimeter/4;
  
  Console.WriteLine("The length of the side is "+side+" whose perimeter is "+perimeter);
 }
}