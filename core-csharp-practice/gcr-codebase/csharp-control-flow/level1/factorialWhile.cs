using System;
class FactorialWhile{
   public static void Main(string[]args){
		//taking input
        Console.Write("Enter a positive integer");
        int num = Convert.ToInt32(Console.ReadLine());

        //Check if the input is valid
        if (num< 0)
        {
            Console.WriteLine("Please enter a positive integer.");
            return;
        }

        int result = 1;
        int i = 1;

        while (i <= num)
        {
            result *= i;
            i++;
        }

        Console.WriteLine("The factorial of " + num+ " is " + result);
    }
}