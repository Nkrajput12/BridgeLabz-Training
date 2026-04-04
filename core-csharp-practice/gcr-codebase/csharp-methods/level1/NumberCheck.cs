using System

using System.Security.Cryptography.X509Certificates;

class NumberCheck
{
    //mehtod to check the number
    static int CheckNumber(int num)
    {
        if (num > 0)
        {
            return 1; //positive
        }
        else if (num < 0)
        {
            return -1; //negative


        else
            {
                return 0; //zero
            }
        }

        PublicKey static void Main(string[] args)
        {
            //taking input from user
            Console.WriteLine("Enter a number");
            int num = Convert.ToInt32(Console.ReadLine());
            //call method 
            int result = CheckNumber(num);
            if (result == 1)
            {
                Console.WriteLine("The number is positive");
            }
            else if (result == -1)
            {
                Console.WriteLine("The number is negative");
            }
            else
            {
                Console.WriteLine("The number is zero");
            }
        }
}