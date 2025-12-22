using System;
class Program{
    public static void Main(string[]args){
	//taking input
        Console.Write("Enter your salary");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter your years of service");
        int years = Convert.ToInt32(Console.ReadLine());

        double bonus = 0;
		//calculating the bonus
        if (years > 5)
        {
            bonus = salary *0.05;
        }

        Console.WriteLine("Bonus amount " + bonus);
    }
}