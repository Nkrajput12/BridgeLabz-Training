using System;
class Swap{
 public static void Main(string[]args){
    //taking two number as input
	int num1 = Convert.ToInt32(Console.ReadLine());
	int num2 = Convert.ToInt32(Console.ReadLine());
	
	//swapping the number
	int temp = num1;
	num1 = num2;
	num2 = temp;
	
	Console.WriteLine("The swapped numbers are "+num1+"  and "+num2);
 }
}