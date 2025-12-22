
using System;
class Calculator{
 public static void Main(String[]args){
   float num1 = Convert.ToSingle(Console.ReadLine());
   float num2 = Convert.ToSingle(Console.ReadLine());
   
   float add = num1+num2;
   float sub = num1-num2;
   float mul = num1*num2;
   float div = num1/num2;
   
   Console.WriteLine("The addition, subtraction, multiplication and division value of 2 numbers "+num1+" and "+num2+" is " +add+", "+sub+", "+mul+", and "+div);
 
 }
}
 
 