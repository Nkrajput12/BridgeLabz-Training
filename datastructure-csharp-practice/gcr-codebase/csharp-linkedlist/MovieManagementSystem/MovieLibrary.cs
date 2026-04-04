using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.MovieManagementSystem
{
    public class MovieLibrary
    {
        private MovieNode head = null;
        private MovieNode tail = null;

        // 1. Add Movie
        public void AddBeginning(string t, string d, int y, double r)
        {
            MovieNode newNode = new MovieNode(t, d, y, r);
            if (head == null) { head = tail = newNode; }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
        }

        public void AddEnd(string t, string d, int y, double r)
        {
            MovieNode newNode = new MovieNode(t, d, y, r);
            if (tail == null) { head = tail = newNode; }
            else
            {
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void AddAtPosition(int pos, string t, string d, int y, double r)
        {
            if (pos <= 1) { AddBeginning(t, d, y, r); return; }

            MovieNode newNode = new MovieNode(t, d, y, r);
            MovieNode temp = head;
            for (int i = 1; temp != null && i < pos - 1; i++) temp = temp.Next;

            if (temp == null || temp == tail) { AddEnd(t, d, y, r); }
            else
            {
                newNode.Next = temp.Next;
                newNode.Prev = temp;
                temp.Next.Prev = newNode;
                temp.Next = newNode;
            }
        }

        // 2. Remove by Title
        public void RemoveByTitle(string title)
        {
            MovieNode current = head;
            while (current != null)
            {
                if (current.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    if (current == head) { head = head.Next; if (head != null) head.Prev = null; }
                    else if (current == tail) { tail = tail.Prev; tail.Next = null; }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    Console.WriteLine($"Removed: {title}");
                    return;
                }
                current = current.Next;
            }
            Console.WriteLine("Movie not found.");
        }

        // 3. Search by Director or Rating
        public void SearchByDirector(string director)
        {
            MovieNode temp = head;
            bool found = false;
            while (temp != null)
            {
                if (temp.Director.Equals(director, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found: {temp.Title} ({temp.Year}) - Rating: {temp.Rating}");
                    found = true;
                }
                temp = temp.Next;
            }
            if (!found) Console.WriteLine("No movies found for this director.");
        }

        // 4. Update Rating
        public void UpdateRating(string title, double newRating)
        {
            MovieNode temp = head;
            while (temp != null)
            {
                if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    temp.Rating = newRating;
                    Console.WriteLine("Rating updated successfully.");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Movie not found.");
        }

        // 5. Display (Forward and Reverse)
        public void DisplayForward()
        {
            MovieNode temp = head;
            Console.WriteLine("\n--- Movies (A-Z / First to Last) ---");
            while (temp != null)
            {
                Console.WriteLine($"{temp.Title} | Dir: {temp.Director} | {temp.Year} | Rating: {temp.Rating}");
                temp = temp.Next;
            }
        }

        public void DisplayReverse()
        {
            MovieNode temp = tail;
            Console.WriteLine("\n--- Movies (Reverse Order) ---");
            while (temp != null)
            {
                Console.WriteLine($"{temp.Title} | Dir: {temp.Director} | {temp.Year} | Rating: {temp.Rating}");
                temp = temp.Prev;
            }
        }
    }
}
