using System;
 class Rounds{
 public static void Main(string[]args){
   //taking side as input in meter
   float side1 = Convert.ToSingle(Console.ReadLine());
   float side2 = Convert.ToSingle(Console.ReadLine());
   float side3 = Convert.ToSingle(Console.ReadLine());
   
   //calculating perimeter
   float perimeter = side1+side2+side3;
	
   float distance = 5000; //5km in meter is 5000meter
   //calculating Rounds
   float rounds = distance/perimeter;
   
   Console.WriteLine("The total number of rounds the athlete will run is "+rounds+" to complete 5 km");
   
   
 }
 }