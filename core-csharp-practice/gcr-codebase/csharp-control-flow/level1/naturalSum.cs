
using System;
class Sum{
	public static void Main(String[]args){
		//prompt user for input
		Console.WriteLine("enter a a natural number");
		//taking input
		int num = Convert.ToInt32(Console.ReadLine());
		
		int sum_formula = num*(num+1)/2;
			int sum_while = 0;
			
		if(num>0){
			
			
			while(num>0){
				sum_while += num;
				num--;
			}
		
		
		if(sum_formula == sum_while){
			Console.WriteLine("the sum is " + sum_formula+ " it is  equal in both computations" );
		}
		else{
		    Console.WriteLine("the sum from both computations is not equal");
		}
		}
		else Console.WriteLine("it is not a natural Number");
		
	}
}