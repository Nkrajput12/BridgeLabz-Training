using System;
class Handshake1
{
    //method for calculating handshakes
    static int CalculateHandshakes(int n)
    {
        return (n * (n - 1)) / 2; //formula for handshakes
    }
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter number of students");
        int n = Convert.ToInt32(Console.ReadLine());
        //call method and store the value inside handshake variable
        int handshake = CalculateHandshakes(n);
        Console.WriteLine("number of handshakes are " + handshake);
    }
    
     
}