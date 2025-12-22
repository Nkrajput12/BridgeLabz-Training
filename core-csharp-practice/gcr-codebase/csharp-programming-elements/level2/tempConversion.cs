using System;
class TempConversion{
 public static void Main(string[]args){
   //taking input in celsius
   float celsius = Convert.ToSingle(Console.ReadLine());
   
   //coverting the celsius into fahrenheit
   float fahrenheit = (celsius*9/5)+32;
   
   Console.WriteLine("the "+fahrenheit+" Fahrenheit is "+celsius+" Celsius");
  }
}