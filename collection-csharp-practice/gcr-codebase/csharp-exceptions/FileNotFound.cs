using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_exception
{
    internal class FileNotFound
    {
        public static void Main(string[] args)
        {
            try
            {
                // Attempt to read a file that does not exist
                string filePath = "nonexistentfile.txt";
                string fileContent = System.IO.File.ReadAllText(filePath);
                Console.WriteLine(fileContent);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                // Handle the FileNotFoundException
                Console.WriteLine("File not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
