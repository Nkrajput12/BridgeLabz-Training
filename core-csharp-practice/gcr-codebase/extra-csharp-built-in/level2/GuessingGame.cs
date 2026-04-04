using System;
class GuessingGame
{
    //method to generate a random number
    public static int RandomNum(int start, int end)
    {
        Random rand = new Random();
        return rand.Next(start, end);
    }

    //mehtod to get feedback
    public static string Feedback()
    {
        Console.WriteLine("enter your guess: high,low or correct");
        return Console.ReadLine().ToLower();
    }

    public static void Main(string[] args)
    {
        int low = 1, high = 100;
        string feedback;

        Console.WriteLine("Thinking a number between 1 to 100");
        do
        {
            int guess = RandomNum(low, high);
            Console.WriteLine("the guess is = " + guess);
            feedback = Feedback();
            if (feedback == "high")
            {
                high = guess - 1;

            }
            else if (feedback == "low")
            {
                low = guess + 1;
            }


        } while (feedback != "correct");
        Console.WriteLine("successfully guessed");


            
    }
}