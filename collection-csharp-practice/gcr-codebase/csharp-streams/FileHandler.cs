using System;
using System.IO;

class FileHandler
{
    public static void Main(string[] args)
    {
        string sourcePath = "C:\\Users\\nkr88\\OneDrive\\Desktop\\file.txt";
        string destinationPath = "C:\\Users\\nkr88\\OneDrive\\Desktop\\Destination.txt";

        // Check if source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Error: The source file does not exist.");
            return;
        }

        try
        {
            // Initialize FileStreams within 'using' blocks for automatic disposal
            using (FileStream fsRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream fsWrite = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                // Create a buffer (8KB is a standard size)
                byte[] buffer = new byte[8192];
                int bytesRead;

                Console.WriteLine("Copying file...");

                // Read from source and write to destination
                while ((bytesRead = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsWrite.Write(buffer, 0, bytesRead);
                }

                Console.WriteLine("Success: File content copied to " + destinationPath);
            }
        }
        catch (IOException ex)
        {
            // Handle IO specific errors (e.g., file in use, disk full)
            Console.WriteLine($"An IO error occurred: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}