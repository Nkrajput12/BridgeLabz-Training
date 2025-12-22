
using System;
class Fee{
 public static void Main(string[]args){
  int fee = Convert.ToInt32(Console.ReadLine());
  float discountPercent = Convert.ToSingle(Console.ReadLine());
  
  float discount = fee/100*discountPercent; // calculate discount fee by formula
  
  float discounted_fee = fee - discount; // discounted fees after subtracting discount from fee
  
  Console.WriteLine("The discount amount is INR " +discount+ " and final discounted fee is INR " + discounted_fee);
 }
}