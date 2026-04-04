using System;
class Multiple{
	public static void Main(string[]args){
		//taking input
		Console.WriteLine("Enter number");
		int number = Convert.ToInt32(Console.ReadLine());
		//check if the number is below 100 or not
		if(number<100){
			for(int i=100;i>0;i--)
			if(i%number == 0){
				Console.WriteLine(i);
				continue;
			}
		}
		else{
			Console.WriteLine("enter number below 100");
		}
	}
}