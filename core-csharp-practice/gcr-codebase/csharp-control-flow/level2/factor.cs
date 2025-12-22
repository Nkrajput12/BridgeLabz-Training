using System;
class Factor {
    public static void Main(string[]args) {
		//taking inputs
        Console.WriteLine("Enter a number");
        int number = Convert.ToInt32(Console.ReadLine());
		
        int greatestFactor = 1;
		
		//computing the greatestFactor
        for (int i = number - 1; i >= 1; i--) {
            if (number % i == 0) {
                greatestFactor = i;
                break;
            }
        }
        Console.WriteLine(greatestFactor);
    }
}