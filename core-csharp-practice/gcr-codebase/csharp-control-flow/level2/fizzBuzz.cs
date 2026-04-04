using System;
class FizzBuzzGame {
    public static void Main(string[]args) {
        Console.WriteLine("Enter a number");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number < 0) {
            Console.WriteLine("Please enter a positive integer.");
        } else {
            for (int i=0;i<=number;i++) {
            if (i%3==0 && i%5==0) {
                Console.WriteLine("FizzBuzz");
           } else if (i%3==0) {
                    Console.WriteLine("Fizz");
             } else if (i%5==0) {
                 Console.WriteLine("Buzz");
             } else {
                 Console.WriteLine(i);
                }
            }
        }
    }
}