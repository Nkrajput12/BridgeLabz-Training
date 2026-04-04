using System;
class TempConversion2{
 public static void Main(string[]args){
   //taking input in fahrenheit
   float fahrenheit = Convert.ToSingle(Console.ReadLine());
   
   //coverting the fahrenheit into celsius
   float celsius = (fahrenheit-32)*5/9;
   
   Console.WriteLine("the "+fahrenheit+" Fahrenheit is "+celsius+" Celsius");
  }
}