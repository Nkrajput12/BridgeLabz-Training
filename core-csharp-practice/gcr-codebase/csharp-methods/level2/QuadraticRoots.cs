using System;
class QuadraticRoots
{
    public static  void Main(string[] args)
    {
        //taking input  a, b and c
        Console.WriteLine("Enter coefficient a:");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter coefficient b:");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter coefficient c:");
        double c = Convert.ToDouble(Console.ReadLine());

        //calling method to calculate roots
        double[] roots = CalculateRoots(a, b, c);

        //displaying roots
        if (roots.Length == 2)
        {

            Console.WriteLine("Root 1 "+roots[0]);

            Console.WriteLine("Root 2 "+roots[1]);
        }
        else if (roots.Length == 1)
        {
          
            Console.WriteLine("Root "+roots[0]);
        }
        else
        {
            Console.WriteLine("Roots are complex.");
        }

    }
    //method of calculating roots
    public static double[] CalculateRoots(double a, double b, double c)
    {
        //calculating delta
        double delta = b*b+4*a*c;
        if (delta > 0)
        {
            double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double root2 = (-b - Math.Sqrt(delta)) / (2 * a);

            return new double[] { root1, root2 };
        }
        else if (delta == 0)
        {
            double root = -b / (2 * a);

            return new double[] { root };
        }
        else
        {
            return new double[] {  };
        }



    }
}
