using System;

class LuckyDraw
{
    // We make the Random object a 'field' so all methods can see it
    static Random _random = new Random();

    static void Main()
    {
        Console.WriteLine("✨ Welcome to the Modular Diwali Lucky Draw! ✨");
        RunMela();
    }

    // Method The Main Controller Loop
    static void RunMela()
    {
        while (true)
        {
            Console.Write("\nType 'draw' to get a number or 'exit' to quit: ");
            string input = Console.ReadLine().ToLower().Trim();

            if (input == "exit") break;

            // Use 'continue' if validation fails
            if (!IsValidInput(input))
            {
                Console.WriteLine(" Invalid command! Please type 'draw'");
                continue;
            }

            int luckyNumber = GenerateNumber(1, 100);
            bool win = CheckWinning(luckyNumber);

            DisplayResult(luckyNumber, win);
        }
    }

    // Method to Validation of input
    static bool IsValidInput(string input)
    {
        return input == "draw";
    }

    // Method 3: Number Generation
    static int GenerateNumber(int min, int max)
    {
        return _random.Next(min, max + 1);
    }

    // Method to check for winner
    static bool CheckWinning(int number)
    {
        // Returns true if divisible by 3 AND 5
        return (number % 3 == 0 && number % 5 == 0);
    }

    // Method to Display 
    static void DisplayResult(int number, bool isWinner)
    {
        Console.WriteLine($"Your number is: {number}");
        if (isWinner)
        {
            Console.WriteLine("BIG WINNER! You get a special Diwali Gift!");
        }
        else
        {
            Console.WriteLine("No prize this time");
        }
        Console.WriteLine("---------------------------------------");
    }
}