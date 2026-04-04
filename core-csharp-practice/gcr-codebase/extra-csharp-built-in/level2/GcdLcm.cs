using System;

class GcdLcm
{
    //method to calcualte GCD
    static int GetGcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    //methjod to calcualte LCM
    static int GetLcm(int a, int b)
    {
        return (a * b) / GetGcd(a, b);
    }

    static void Main()
    {
        //tak the fist and second number as input from user
        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());


        //call mehtod and display result
        Console.WriteLine("GCD: " + GetGcd(num1, num2));
        Console.WriteLine("LCM: " + GetLcm(num1, num2));
    }
}