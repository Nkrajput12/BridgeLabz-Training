using System;
class AthleteRun
{
    //method for calculating Rounds
    static double rounds(double side1, double side2, double side3)
    {
        double perimeter = side1 + side2 + side3; //calculating perimeter

        return 5000/ perimeter; //calculating rounds 5km = 5000 meters
    }
    public static void Main(string[] args)
    {
        //taking inputs from user
        Console.WriteLine("Enter side1 in meters");
        double side1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter side2 in meters");
        double side2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter side3 in meters");
        double side3 = Convert.ToDouble(Console.ReadLine());


        //call method and store the value inside rounds variable
        double roundsCompleted = rounds(side1, side2, side3);
        Console.WriteLine("Number of rounds athlete must complete " + roundsCompleted);
    }
}