using System;
class Totalincome{
 public static void Main(string[]args){
   //taking salary and bonus as input
   float salary = Convert.ToSingle(Console.ReadLine());
   float bonus = Convert.ToSingle(Console.ReadLine());
   
   //calculating total salary
   float total_income = salary+bonus;
   
   Console.WriteLine("The salary is INR"+salary+" and bonus is INR"+bonus+".Hence Total Income is INR"+total_income);
 }
}