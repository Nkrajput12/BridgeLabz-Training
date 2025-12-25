using System;

class Geometry9
{
    //method of calculating Euclidean Distance
    public static double EuclideanDistance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    //method for  Calculate equation of line (y = m*x + b)
    public static double[] LineEquation(double x1, double y1, double x2, double y2)
    {
        double m = (y2 - y1) / (x2 - x1);
        double b = y1 - m * x1;
        return new double[] { m, b };
    }

    static void Main()
    {   //taking user input
        Console.Write("Enter x1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter y1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter x2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter y2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());


        //calling methods 

        double distance = EuclideanDistance(x1, y1, x2, y2);
        double[] line = LineEquation(x1, y1, x2, y2);

        //printing result
        Console.WriteLine($"Euclidean Distance = {distance:F2}");
        Console.WriteLine($"Equation of line: y = {line[0]:F2}x + {line[1]:F2}");
    }
}