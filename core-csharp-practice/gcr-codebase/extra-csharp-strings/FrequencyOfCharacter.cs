using System;

class FrequencyOfCharacter
{
    public static void Main(string[]args)
    {
        // 1. Get input from the user
        Console.Write("Enter a string: ");
        string text = Console.ReadLine() ?? "";

        // 2. Call method
        char result = Frequent(text);

        // 3. Output the result
        if (text.Length > 0)
        {
            Console.WriteLine($"The most frequent character is: '{result}'");
        }
        else
        {
            Console.WriteLine("The string is empty.");
        }
    }

    
    /// Finds the character that appears most often in a string.
    
    public static char Frequent(string input)
    {
      

        int maxCount = 0;
        char mostFrequent = input[0];

        
        for (int i = 0; i < input.Length; i++)
        {
            int currentCount = 0;

            
            for (int j = 0; j < input.Length; j++)
            {
                if (input[i] == input[j])
                {
                    currentCount++;
                }
            }

            // Update max if we found a higher count
            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                mostFrequent = input[i];
            }
        }

        return mostFrequent;
    }
}