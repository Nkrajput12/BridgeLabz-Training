using System;
using System.Security.Cryptography.X509Certificates;
class BMI
{
    //method for calculating BMI
    public static double[] Bmi(double[]weight , double[] height)
    {
        double[] bmiValues = new double[weight.Length];
        for (int i = 0; i < weight.Length; i++)
        {
            double hinM = height[i] / 100; // converting height from cm to meters
            bmiValues[i] = weight[i] / (hinM * hinM);
        }
        return bmiValues;
    }

    //method for BMI status
    public static string[] BmiStatus(double[] bmiValues)
    {
        string[] status = new string[bmiValues.Length];
        for (int i = 0; i < bmiValues.Length; i++)
        {
            if (bmiValues[i] < 18.5)
            {
                status[i] = "Underweight";
            }
            else if (bmiValues[i] >= 18.5 && bmiValues[i] <= 24.9)
            {
                status[i] = "Normal";
            }
            else if (bmiValues[i] >= 25 && bmiValues[i] <= 39.9)
            {
                status[i] = "Overweight";
            }
            else
            {
                status[i] = "Obese";
            }
        }
        return status;

        
    }
    public static void Main(string[] args)
    {
        //taking input from user

        double[] weight = new double[10];
        double[] height = new double[10];
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Enter weight (in kg) of member " + (i + 1));
            weight[i] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter height (in cm) of member " + (i + 1));
            height[i] = Convert.ToDouble(Console.ReadLine());
        }
        double[] bmiValues = Bmi(weight, height);
        string[] status = BmiStatus(bmiValues);
        //displaying BMI and status
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Member " + (i + 1) + " with height = " + height[i] +" and weight = "+weight[i] + "is having  BMI = " + bmiValues[i] + " and Status = " + status[i]);
        }
    }
}
