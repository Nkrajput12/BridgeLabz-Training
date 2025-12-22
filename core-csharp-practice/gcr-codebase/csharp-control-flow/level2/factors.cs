using System;
class Factors{
	public static void Main(string[]args){
		//taking input
		Console.WriteLine("Enter number");
		int number = Convert.ToInt32(Console.ReadLine());
		//find factors
		for(int i =1;i<number;i++){
			if(number%i==0) Console.WriteLine(i);
		}
	}
}