using System;
class fizzBuzzarray
{
    static void Main(string[] args)
    {
        //taking input
        Console.WriteLine("Enter a number");
        int n = Convert.ToInt32(Console.ReadLine());
        
        if(n<= 0)
        {
            Console.Error.WriteLine("please enter a natural number");
            Environment.Exit(0);
        }

        string[] str = new string[n];

        //store in array
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                str[i - 1] = "FizzBuzz";
            }
            else if (i % 3 == 0)
            {
                str[i - 1] = "Fizz";
            }
            else if (i % 5 == 0)
            {
                str[i - 1] = "Buzz";
            }
            else
            {
                str[i - 1] = i.ToString();
            }
        }
        // Print array
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(str[i]);
        }
        
    }

}

