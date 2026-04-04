using System;
class Bonus
{
    public static void Main(string[]args)
    {   //intialize the arrays
        double[] salary = new double[10];
        double[] service = new double[10];
        double[] bonus = new double[10];
        double[] new_salary = new double[10];

        double total_bonus = 0;

        //taking salary input from user
        Console.WriteLine("Enter the salary of 10 employees");
        for(int i=0;i<10;i++)
        {
            Console.Write("Employee " +(i+1)+" ");
            salary[i] = Convert.ToDouble(Console.ReadLine());
        }

        //taking service input from user
        Console.WriteLine("Enter the service of 10 employees");
        for(int i=0;i<10;i++)
        {
            Console.Write("Employee " +(i+1)+" ");
            service[i] = Convert.ToDouble(Console.ReadLine());
        }

        //calculating bonus and new salary
        for (int i = 0; i < 10; i++)
        { 
            if (service[i] > 5)
            {
                bonus[i] = salary[i] * 0.05;
            }
            else
            {
                bonus[i] = salary[i]*0.02;
            }
            new_salary[i] = salary[i] + bonus[i];
            total_bonus += bonus[i];
        }
        //print results
        Console.WriteLine("The company Zara has to pay "+total_bonus);
        for(int i=0;i<10;i++)
        {
            Console.WriteLine("The Old salary of Employee "+(i+1)+" is " + salary[i]+" and new salary along with bonus is " + new_salary[i]);
        }


    }
}