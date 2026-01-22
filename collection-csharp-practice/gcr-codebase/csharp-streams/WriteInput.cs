using System;
using System.IO;

class WriteInput
{
    static void Main()
    {
        // This is where we'll save the data. It'll show up in your project folder.
        string filePath = "C:\\Users\\nkr88\\OneDrive\\Desktop\\file.txt";

        // We're opening a "reader" to listen to what you type into the console.
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
        {
            try
            {
                // We ask a question, then wait for the user to hit 'Enter'
                Console.Write("Enter your name: ");
                string name = reader.ReadLine();

                Console.Write("Enter your age: ");
                string age = reader.ReadLine();

                Console.Write("Enter your favorite programming language: ");
                string language = reader.ReadLine();

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("\n--- New Entry ---");
                    writer.WriteLine($"Name: {name}");
                    writer.WriteLine($"Age: {age}");
                    writer.WriteLine($"Language: {language}");
                    writer.WriteLine("-----------------");
                    // We don't need to 'Close' the writer because the 'using' block does it for us!
                }

                Console.WriteLine("\nDone! ");
            }
            catch (Exception ex)
            {
                // If the computer is grumpy (like no disk space or a locked file), this runs.
                Console.WriteLine($"Whoops! Something went wrong: {ex.Message}");
            }
        }

        // Just stops the window from closing instantly so you can read the success message.
        Console.WriteLine("Press any key to shut this down...");
        Console.ReadKey();
    }
}