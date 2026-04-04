
using System;
class TotalSum{
	public static void Main(string[]args){
		//prompt user for input
		Console.WriteLine("enter number");
		//taking input
		double num = Convert.ToDouble(Console.ReadLine());
		double sum = 0;
		
		while(num !=0){
			sum += num;
			//prompt user for input
			Console.WriteLine("enter number");
			//taking input
			num = Convert.ToDouble(Console.ReadLine());
		}
		Console.WriteLine("the total value is "+sum);
	}
}