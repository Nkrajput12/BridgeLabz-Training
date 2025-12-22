
using System;
class DivisionCalculator{
 public static void Main(string[]args){
  int num1 = Convert.ToInt32(Console.ReadLine());
  int num2 = Convert.ToInt32(Console.ReadLine());
  
  float quotient = num1/num2; //calculating the quotient
 
  int remainder = num1%num2; //calculating the remainder
  
  Console.WriteLine("The Quotient is "+quotient+" and Remainder is "+remainder+" of two number "+num1+" and "+num2);
 }
 }