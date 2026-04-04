using System;
class OddEven{
    public static void Main(string[]args){
	
		//taking input from user
        Console.Write("Enter a number");
        int num = Convert.ToInt32(Console.ReadLine());
   
        for (int i = 1; i <= num ; i++)
        {   if (i % 2 == 0){
                Console.WriteLine(i + " is a Even number");
            }
            else{
                Console.WriteLine(i + " is a Odd number");
            }
        }
    }
}