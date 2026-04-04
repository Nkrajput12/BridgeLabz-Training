using System;
class SumElements
{
    public static void Main(string[] args)
    {
        //array intialization
        double[] arr = new double[10];
        double sum = 0.0;

        int i = 1;

        Console.WriteLine("Enter the elements");
        while (true)
        {   //checking for maximum 10 elements
            if (i > 10)
            {
                break;
            }
            //taking input from user
            double num = Convert.ToDouble(Console.ReadLine());


            if (num <= 0)
            {
                break;

            }
            else
            {
                arr[i - 1] = num;
                sum += arr[i - 1];
                

            }
            i++;

        }
        Console.WriteLine("Sum of the elements: " + sum);

    }
}
    