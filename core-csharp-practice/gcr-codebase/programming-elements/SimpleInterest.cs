using System;
public class SimpleInterest{
 public static void Main(string[] args){

	double Principal = 4000;
	double Rate = 10;
	int time = 5;
	
	double Interest = (Principal*Rate*time)/100;
	
	Console.WriteLine(Interest);
	}
}
	
	