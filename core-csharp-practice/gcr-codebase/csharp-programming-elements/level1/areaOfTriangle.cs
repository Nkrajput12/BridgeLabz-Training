
using System;
class Area{
 public static void Main(string[]args){
  double width = Convert.ToDouble(Console.ReadLine());
  double height = Convert.ToDouble(Console.ReadLine());
  //calculating width and height in inches.
  double width_inches = width/2.54;
  double height_inches = height/2.54;
  //calculating Area in inches
  double area_cm = 1.0/2.0*width*height;
  double area_inches = 1.0/2.0*width_inches*height_inches;
  
  Console.WriteLine("Area of Tringle in square inches "+area_inches+" and in square centimeters "+area_cm);
  
  
 }
}