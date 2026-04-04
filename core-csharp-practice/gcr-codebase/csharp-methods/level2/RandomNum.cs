using System;

class RandomNum
{
    //method for generating random 4-digit numbers
    public static int[] GetRandomArray(int size)
    {
        Random rand = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
            arr[i] = rand.Next(1000, 10000); // 4-digit number
        return arr;
    }

    //find the  average, min, and max
    static double[] AvgMinMax(int[] numbers)
    {
        int min = numbers[0], max = numbers[0], sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            min = Math.Min(min, numbers[i]);
            max = Math.Max(max, numbers[i]);
        }
        double avg = sum / (double)numbers.Length;
        return new double[] { avg, min, max };
    }

    static void Main()
    {
        //takig size as input
        Console.WriteLine("enter size");
        int size = Convert.ToInt32(Console.ReadLine());
        //generate random numberss
        int[] nums = GetRandomArray(size);

        //print the generated numbers
        for(int i = 0; i < nums.Length; i++)
        {
            Console.WriteLine("Generated number " + (i + 1) + " = " + nums[i]);
        }

        double[] result = AvgMinMax(nums);

        Console.WriteLine("Average: " + result[0] + ", Min: " + result[1] + ", Max: " + result[2]);
    }
}