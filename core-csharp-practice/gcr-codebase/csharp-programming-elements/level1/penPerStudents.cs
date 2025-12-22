
using System;	
class pendivide{
 public static void Main(string[]agrs){ 
	int pen = 14;
	int students = 3;
	
	int pen_per_student = pen/students;// use divide operator to find pen per students
	int rem = pen%students; //use modulus operator to find the remaining pens
	
	Console.WriteLine("The Pen Per Student is " + pen_per_student + " and the remaining pen not distributed is " + rem);
	
 }
}
