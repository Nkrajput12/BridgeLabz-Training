
using System;
class Sum{
	public static void Main(String[]args){
		//prompt user for input
		Console.WriteLine("enter a a natural number");
		//taking input
		int num = Convert.ToInt32(Console.ReadLine());
		
		int sum_formula = num*(num+1)/2;
			int sum_for = 0;
			
		if(num>0){
			for(int i = num;i>0;i--){
				sum_for += i;
			}
	
			if(sum_formula == sum_for){
			Console.WriteLine("the sum is " + sum_formula+ " it is  equal in both computations" );
			}
			else{
		    Console.WriteLine("the sum from both computations is not equal");
			}
		}
		else Console.WriteLine("it is not a natural Number");
		
	}
}