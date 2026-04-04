using System;
class Armstrong{
	public static void Main(string[]args){
		//taking input
		Console.WriteLine("enter the number");
		int number = Convert.ToInt32(Console.ReadLine());
		// store number in temp variable
		int temp = number;
		int sum = 0;
		int rev = 0;
		
		//calculating cube to the remaninder and add
		while(temp>0){
			rev = temp%10;
			sum +=  rev*rev*rev;
			
			temp = temp/10;
			
		}
		if(sum == number) {
			Console.WriteLine("its an Armstrong number");
			
		}
		else {
			Console.WriteLine("it is not an Armstrong number");
		}
		
	}
}