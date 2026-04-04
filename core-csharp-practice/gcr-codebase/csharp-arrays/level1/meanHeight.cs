using System;
class MeanHeight
{
    public static void Main(string[] args)
    {
        //array intialization
        double[] heights = new double[11];
        double sum = 0.0;

        for(int i = 0; i < 11; i++)
        {   //taking input from user
            Console.Write("Enter height " + (i + 1) + " ");
            heights[i] = Convert.ToDouble(Console.ReadLine());
            sum += heights[i];
        }

        //calculating mean by dividing sum by number of elements
        double mean = sum / 11;
        Console.WriteLine("Mean Height: " + mean);

    }
}