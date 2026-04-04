using System;

class TypeCasting{
 public static void Main(string[] args){
    double a = 9.1;
	
	object b = (int)a;
	
	if( b is int) Console.WriteLine("b = " + b +" it is Int");
	else Console.WriteLine("b = " + b +" it is not an Int");
	
	object c = (float)a;
	
	if( c is float) Console.WriteLine("c = " + c +" it is float");
	else Console.WriteLine("c = " + c +" it is not float");
	
 }
}