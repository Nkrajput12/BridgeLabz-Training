
using System;
class Discount{
 public static void Main(string[]args){
  int fee = 125000;
  int discountPercent = 10;
  
  int discount = fee/100*discountPercent; // calculate discount fee by formula
  
  int discounted_fee = fee - discount; // discounted fees after subtracting discount from fee
  
  Console.WriteLine("The discount amount is INR " +discount+ " and final discounted fee is INR " + discounted_fee);
 }
}