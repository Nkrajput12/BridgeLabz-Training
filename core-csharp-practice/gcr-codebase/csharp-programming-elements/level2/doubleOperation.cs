using System;
class DoubleOperation{

 public static void Main(){
    //Taking a,b and c input
    double a = Convert.ToDouble(Console.ReadLine());
    double b = Convert.ToDouble(Console.ReadLine());
    double c = Convert.ToDouble(Console.ReadLine());

    // Computing the 4 doubleeger operations
    double res1 = a+b*c;
    double res2 = a*b+c;
    double res3 = c+a/b;
    double res4 = a%b+c;

    Console.WriteLine("The results of double Operations are "+res1+", " +res2+", " +res3+", and " +res4);
    }
}