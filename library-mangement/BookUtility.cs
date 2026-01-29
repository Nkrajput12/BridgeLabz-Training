using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Library_mangement
{
    internal class BookUtility : Book, IBook
    {
        Book[] inventory = new Book[20]; //the inventory size is 20
        public int bookCount = 0;

        public void AddBook()
        {
            if (bookCount == inventory.Length)
            {
                Console.WriteLine("!!!Inventory full!!!");
            }
            else
            {
                Book book = new Book();

                Console.Write("Enter Title : ");
                book.SetTitle(Console.ReadLine());
                Console.Write("Enter Author : ");
                book.SetAuthor(Console.ReadLine());

                book.SetStatus("Available");
                inventory[bookCount++] = book;

                Console.WriteLine("------Book added Successfully---------");


            }
        }

        public void Searching()
        {
            Console.WriteLine("Enter the book title you want to search");
            string str = Console.ReadLine().ToLower();

            for (int i = 0; i < bookCount; i++)
            {
                string title = inventory[i].GetTitle().ToLower();

                if (title.Contains(str))
                {
                    Console.WriteLine("Found");
                    Console.WriteLine("Slot no " + (i + 1) + "Title: " + inventory[i].GetTitle() + " | Author: " + inventory[i].GetAuthor() + " | Status: " + inventory[i].GetStatus());

                }
                else
                {
                    Console.WriteLine("Not Match Found");
                }
            }
        }

        public void Display()
        {
            for (int i = 0; i < bookCount; i++)
            {
                Console.WriteLine("Title: " + inventory[i].GetTitle() + " | Author: " + inventory[i].GetAuthor() + " | Status: " + inventory[i].GetStatus());
            }
        }

        public void CheckOut()
        {
            Console.WriteLine("Enter the slot number of the book ");
            int slot = int.Parse(Console.ReadLine());
            if (inventory[slot - 1].GetStatus() == "Available")
            {
                Console.WriteLine("-----------Book Checkout Successfully----------");
                inventory[slot - 1].SetStatus("Borrowed");
            }
            else
            {
                Console.WriteLine("The Book is already Borrowed");
            }


        }
    }
}
