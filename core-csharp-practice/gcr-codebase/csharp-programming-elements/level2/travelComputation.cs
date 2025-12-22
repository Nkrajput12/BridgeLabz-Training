
using System;
class TravelComputation{
 public static void Main(string[]args){
  //take user inputs for name, fromCity, viaCity, toCity.
  string name = Console.ReadLine();
  string fromCity  = Console.ReadLine();
  string fromToVia = Console.ReadLine();
  string viaToFinalCity = Console.ReadLine();
  
  //take user inputs for distances: fromToVia and viaToFinalCity in miles.
  float fromToVia_distance = Convert.ToSingle(Console.ReadLine());
  float viaToFinalCity_distance = Convert.ToSingle(Console.ReadLine());
  
  //calculating total distance
  float totalDistance = fromToVia_distance+viaToFinalCity_distance;
  
  //take user input about time taken in hr
  float time = Convert.ToSingle(Console.ReadLine());
  
  
  Console.WriteLine("The Total Distance travelled by "+name+" from "+fromCity+" to "+viaToFinalCity+" via "+fromToVia+" is "+totalDistance+" km and the Total Time taken is "+time);
 }
}