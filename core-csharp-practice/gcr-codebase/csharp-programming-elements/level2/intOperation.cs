
using System;
class IntOperation{

 public static void Main(){
    //Taking a,b and c input
    int a = Convert.ToInt32(Console.ReadLine());
    int b = Convert.ToInt32(Console.ReadLine());
    int c = Convert.ToInt32(Console.ReadLine());

    // Computing the 4 integer operations
    int res1 = a+b*c;
    int res2 = a*b+c;
    int res3 = c+ a/b;
    int res4 = a%b+c;

    Console.WriteLine("The results of Int Operations are "+res1+", " +res2+", " +res3+", and " +res4);
    }
}