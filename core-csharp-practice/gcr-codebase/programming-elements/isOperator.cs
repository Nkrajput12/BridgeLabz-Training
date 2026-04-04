using System;

class IsOperator{
 public static void Main(){
   object x = 16;
   
   if(x is int) Console.WriteLine("it is int");
   else Console.WriteLine("it is not an int");
 }
}