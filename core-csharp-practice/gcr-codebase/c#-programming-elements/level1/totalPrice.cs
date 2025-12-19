
using System;
class Total{
 public static void Main(string[]args){
  float unitPrice = Convert.ToSingle(Console.ReadLine());
  int quantity = Convert.ToInt32(Console.ReadLine());
  
  float totalprice = unitPrice*quantity;
  
  Console.WriteLine("The total purchase price is INR " + totalprice+" if the quantity " + quantity+" and unit price is INR " + unitPrice);
 }
}