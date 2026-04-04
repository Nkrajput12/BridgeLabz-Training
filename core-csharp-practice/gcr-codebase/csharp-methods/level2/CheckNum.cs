using System;
class CheckNum
{
    // method for checking if a number is positive
    public static bool Ispositive(int number)
    {
        if (number > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //method for checking if a number is even
    public static bool Iseven(int number)
    {
        if (number % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //method for comparing two numbers
    public static int Compare(int num1, int num2)
    {
        if (num1 > num2)
        {
            return 1;
        }
        else if (num1 < num2)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public static void Main(string[] args)
    {
        //taking input from user
        int[] num = new int[5];
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Enter number " + (i + 1));
            num[i] = Convert.ToInt32(Console.ReadLine());
        }


        
        for(int i=0;i<5;i++)
        {
            //check for positive or negative
            if (Ispositive(num[i]))
            {
                //check for even or odd
                if (Iseven(num[i]))
                {
                    Console.WriteLine("Number " + (i+1)+" is positive even number");
                }
                else
                {
                    Console.WriteLine("Number " + (i+1)+" is positive odd number");
                }
            }
            else
            {
                    Console.WriteLine("Number " + (i+1)+" is negative number");
            }

            
        }
        //compare first and last number
        if (Compare(num[0], num[4]) == 1)
        {
            Console.WriteLine("first is greter than last");
        }
        else if (Compare(num[0], num[4]) == -1)
        {
            Console.WriteLine("first is less than last");
        }
        else
        {
            Console.WriteLine("first is equal to last");
        }
    }

}

