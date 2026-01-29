using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.Library_mangement
{
    public class Book
    {
        private string Title;
        public void SetTitle(string title)
        {
            this.Title = title;
        }
        public string GetTitle()
        {
            return Title;
        }

        private string Author;
        public void SetAuthor(string author)
        {
            this.Author = author;
        }
        public string GetAuthor()
        {
            return Author;
        }
        private string Status;
        public void SetStatus(string status)
        {
            this.Status = status;
        }
        public string GetStatus()
        {
            return Status;
        }

        //public Book(string title, string author, string status)
        //{
        //    this.Title = title;
        //    this.Author = author;
        //    this.Status = status;
        //}       
        public void Display()
        {
            Console.WriteLine("Title : " + Title);
            Console.WriteLine("Author : " + Author);
            Console.WriteLine("Status : " + Status);
        }

    }
}
