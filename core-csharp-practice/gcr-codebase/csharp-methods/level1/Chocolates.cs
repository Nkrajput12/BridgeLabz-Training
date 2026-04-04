using System;
class Chocolates
{
    public static int[] Chocolatesperchild(int child, int chocolates)
    {
        // Calculate the number of chocolates per child
        int perchild = chocolates / child;
        int remaining = chocolates % child;
        return new int[] { perchild, remaining };
    }
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the number of childs");
        int child = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the number of chocolates");
        int chocolates = Convert.ToInt32(Console.ReadLine());
        //call method
        int[] result = Chocolatesperchild(child, chocolates);
        Console.WriteLine("Each child gets " + result[0] + " chocolates");
        Console.WriteLine("Remaining chocolates are " + result[1]);

    }
}

