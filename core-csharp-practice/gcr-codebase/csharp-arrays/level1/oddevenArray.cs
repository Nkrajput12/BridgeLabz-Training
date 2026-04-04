using System;
class OddevenArray
{
    public static void Main(string[] args)
    {   //take number of elements
        Console.WriteLine("Enter the number of elements in the array");
        int n = Convert.ToInt32(Console.ReadLine());
        //check for natural number
        if (n <= 0)
        {
            Console.Error.WriteLine("please enter natural number");
            Environment.Exit(0);
        }
        //intialize array
        int[] arr = new int[n];
        //take input from user
        Console.WriteLine("Enter the elements of the array");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        //intialize odd and even arrays
        int[] odd = new int[n / 2 + 1];
        int[] even = new int[n / 2 + 1];

        //intialize odd and even counter
        int oddnum = 0;
        int evennum = 0;

        //add numbers to odd and even arrays
        for (int i = 0, j = 0, k = 0; i < n; i++)
        {
            if (arr[i] % 2 == 0)
            {
                even[j] = arr[i];
                j++;
                oddnum++;
            }
            else
            {
                odd[k] = arr[i];
                k++;
                evennum++;
            }
        }

        //print even arrays
        Console.WriteLine("Even numbers in the array");
        for(int i = 0; i < evennum; i++)
        {
              
            Console.WriteLine(even[i]);
            
        }

        //print odd array
        Console.WriteLine("Odd numbers in the array");
        for(int i = 0; i < evennum; i++)
        {
            Console.WriteLine(odd[i]);
        }
    }
}