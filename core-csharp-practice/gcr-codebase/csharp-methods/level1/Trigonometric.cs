using System;
class Trigonometric
{
    public static double[] calculate(double degree)
    {   //converting degree to radian
        double radian = degree * (Math.PI / 180);
        //calculating sine, cosine and tangent
        double[] results = new double[3];
        results[0] = Math.Sin(radian);
        results[1] = Math.Cos(radian);
        results[2] = Math.Tan(radian);
        return new double[] { results[0], results[1], results[2] };
    }
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the angle in degrees");
        double Degree = Convert.ToDouble(Console.ReadLine());

        //call method
        double[] result = calculate(Degree);

        Console.WriteLine("The Sine value is " + result[0]);
        Console.WriteLine("The Cosine value is " + result[1]);
        Console.WriteLine("The Tangent value is " + result[2]);

    }
}

