using System;
class Fibonacci
{
    //method to generate the fibonacci series
    public static int[] GetFibonacci(int num)
    {
        int[] result = new int[num];
        result[0] = 0;
        if (num == 1) return result;
        result[1] = 1;
        
        if (num == 2) return result;
            for (int i = 2; i < num; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }

        return result;
    }

    //main method
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("enter the size of the fibonacci series");
        int num = Convert.ToInt32(Console.ReadLine());

        int[] result = GetFibonacci(num);

        Console.WriteLine("the fibonacci series ");
        for(int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i]+" ");
        }
    }
}
 
