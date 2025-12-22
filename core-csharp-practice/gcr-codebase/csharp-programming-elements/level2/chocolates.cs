using System;
 class Chocolates{
 public static void Main(string[]args){ 
    //taking input 
	int numberOfChocolates = Convert.ToInt32(Console.ReadLine());
	int numberOfChildren = Convert.ToInt32(Console.ReadLine());
	
	int each_child = numberOfChocolates/numberOfChildren;
	int rem = numberOfChocolates%numberOfChildren;
	
	Console.WriteLine("The number of chocolates each child gets is "+each_child+" and the number of remaining chocolates is"+rem);
	
	
 }
 }