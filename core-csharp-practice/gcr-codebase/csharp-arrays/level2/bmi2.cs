using System;
class BMI2
{
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the number of person");
        int person = Convert.ToInt32(Console.ReadLine());

        //creating arrays to strore weight,height, BMI and status
        double[,] perimeters = new double[person, 3];
        string[] status = new string[person];

        //taking input for height
        Console.WriteLine("Enter height in meter");
        for (int i = 0; i < person; i++)
        {
            Console.WriteLine("person " + (i + 1) + " ");
            
                perimeters[i, 0] = Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine("Enter weight in kg");
        for (int i = 0; i < person; i++)
        {
            Console.WriteLine("person " + (i + 1) + " ");
            perimeters[i, 1] = Convert.ToDouble(Console.ReadLine());
        }

        //calculate the BMI 
        for (int i = 0; i < person; i++)
        {
            perimeters[i, 2] = perimeters[i, 1] / (perimeters[i, 0] * perimeters[i, 0]);

        }

        //computing status
        for (int i = 0; i < person; i++)
        {
            if (perimeters[i, 2] <= 18.4)
            {
                status[i] = "Underweight";
            }
            else if (perimeters[i, 2] >= 18.5 && perimeters[i, 2] <= 24.9)
            {
                status[i] = "Normal";
            }
            else if (perimeters[i, 2] >= 25 && perimeters[i, 2] <= 39.9)
            {
                status[i] = "Overweight";
            }
            else
            {
                status[i] = "Obese";
            }
        }
        //print the results
        for (int i = 0; i < person; i++)
        {
            Console.WriteLine("For person " + (i + 1) + " height = " + perimeters[i, 0] + ", weight = " + perimeters[i, 1] + ", BMI = " + perimeters[i, 2] + " its status = " + status[i]);
        }
    }
}