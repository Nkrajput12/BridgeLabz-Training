
using System;
class Handshake{
 public static void Main(string[]args){
  int students = Convert.ToInt32(Console.ReadLine());
  //calculate the maximum no of handshakes
  int handshakes = (students*(students-1))/2;
  
  Console.WriteLine("Number of possible handshakes are "+handshakes);
 }
}