//leetcode problem number 27 Remove Elements

using System;

public class Solution
{ 
    //method for remove elements
    public static int RemoveElement(int[] nums, int val)
    {
        int i = 0;
        for (int j = 0; j < nums.Length; j++)
        {
            if (nums[j] != val)
            {
                nums[i] = nums[j];
                i++;
            }
        }
        return i;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter the number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] nums = new int[n];

        Console.WriteLine("Enter the elements:");
        for (int i = 0; i < n; i++)
        {
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("Enter the value to remove: ");
        int val = int.Parse(Console.ReadLine());

        
        int newLength = RemoveElement(nums, val);

        Console.WriteLine("New length after removal: " + newLength);
        Console.WriteLine("Updated array:");

        for (int i = 0; i < newLength; i++)
        {
            Console.Write(nums[i] + " ");
        }
    }
}

