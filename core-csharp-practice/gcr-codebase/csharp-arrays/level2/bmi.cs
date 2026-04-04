using System;
class BMI
{
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the number of person");
        int person = Convert.ToInt32(Console.ReadLine());

        //creating arrays to strore weight,height, BMI and status
        double[] weight = new double[person];
        double[] height = new double[person];
        double[] bmi = new double[person];
        string[] status = new string[person];

        //taking input for height
        Console.WriteLine("Enter height in meter");
        for(int i = 0; i < person; i++)
        {
            Console.WriteLine("person " + (i + 1) + " ");
            height[i] = Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine("Enter weight in kg");
        for (int i = 0; i < person; i++)
        {
            Console.WriteLine("person " + (i + 1) + " ");
            weight[i] = Convert.ToDouble(Console.ReadLine());
        }

        //calculate the BMI 
        for(int i = 0; i < person; i++)
        {
            bmi[i] = weight[i] / (height[i] * height[i]);

        }

        //computing status
        for(int i = 0; i < person; i++)
        {
            if (bmi[i] <= 18.4)
            {
                status[i] = "Underweight";
            }
            else if (bmi[i]>=18.5 && bmi[i] <= 24.9)
            {
                status[i] = "Normal";
            }
            else if (bmi[i]>=25 && bmi[i] <= 39.9)
            {
                status[i] = "Overweight";
            }
            else
            {
                status[i] = "Obese";
            }
        }
         //print the results
        for(int i=0;i<person;i++)
        {
            Console.WriteLine("For person " + (i + 1) + " height = " + height[i] + ", weight = " + weight[i] + ", BMI = " + bmi[i] + " its status = " + status[i]);
        }
    }
}