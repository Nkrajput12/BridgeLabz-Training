using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Digital_Bookshelf
{
    public class BookUtility
    {
        // A simple list to hold our strings
        List<string> bookshelf = new List<string>();

        public void AddBook(string title, string author)
        {
            // Simple check: is the text empty?
            if (title == "" || author == "")
            {
                throw new InvalidBookFormatException("You must enter both a title and an author!");
            }

            // Combine them with a simple dash
            string bookData = title + " - " + author;
            bookshelf.Add(bookData);
            Console.WriteLine("Added!");
        }

        public void DisplayAll()
        {
            
            if (bookshelf.Count == 0)
            {
                Console.WriteLine("Your shelf is empty.");
            }
            else
            {
                foreach (string book in bookshelf)
                {
                    Console.WriteLine(book);
                }
            }
        }

        public void SortBooks()
        {
            if (bookshelf.Count > 0)
            {
                bookshelf.Sort();
                Console.WriteLine("Sorted alphabetically!");
            }
        }

        public void SearchByAuthor(string name)
        {
            bool found = false;
            foreach (string book in bookshelf)
            {
                
                string[] parts = book.Split('-');

                
                if (parts.Length > 1 && parts[1].ToLower().Contains(name.ToLower()))
                {
                    Console.WriteLine("Found it: " + book);
                    found = true;
                }
            }

            if (found == false)
            {
                Console.WriteLine("Could not find that author.");
            }
        }

        public string[] ExportToArray()
        {
            
            
            return bookshelf.ToArray();
        }
    }

    public class InvalidBookFormatException : Exception
    {
        public InvalidBookFormatException(string message) : base(message) { }
    }
}
