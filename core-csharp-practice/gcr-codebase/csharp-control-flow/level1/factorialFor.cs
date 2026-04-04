using System;
class FactorialFor{
   public static void Main(string[]args){
		//taking input
        Console.WriteLine("Enter a positive integer");
        int num = Convert.ToInt32(Console.ReadLine());

        //Check if the input is valid
        if (num< 0)
        {
            Console.WriteLine("Please enter a positive integer.");
            return;
        }

        int result = 1;
        for(int i = num;i>0;i--){
			result *= i;
			
		}

        Console.WriteLine("The factorial of " + num+ " is " + result);
    }
}