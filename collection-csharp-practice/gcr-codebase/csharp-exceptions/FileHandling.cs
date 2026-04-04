using System;
using System.IO; // Required for File handling

namespace FileHandlingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\nkr88\\OneDrive\\Desktop\\file.txt";

            // We wrap the process in a try block to catch IO related errors
            try
            {
                // The 'using' statement ensures the StreamReader is disposed of automatically
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string firstLine = reader.ReadLine();

                    if (firstLine != null)
                    {
                        Console.WriteLine("First line of the file:");
                        Console.WriteLine(firstLine);
                    }
                    else
                    {
                        Console.WriteLine("The file is empty.");
                    }
                }
                // At this point, the file is automatically closed.
            }
            catch (FileNotFoundException)
            {
                // Specific error if the file is missing
                Console.WriteLine("Error: The file 'info.txt' was not found.");
            }
            catch (IOException ex)
            {
                // General IO error (file in use, permission issues, etc.)
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("\nTask completed.");
        }
    }
}