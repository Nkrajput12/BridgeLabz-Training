using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.StudentManagement_
{
    public class StudentList
    {
        private StudentNode head = null;

        public void AddBeginning(int roll, string name, int age, char grade)
        {
            StudentNode newNode = new StudentNode(roll, name, age, grade);
            newNode.Next = head;
            head = newNode;
            Console.WriteLine("Success: Student added at the beginning.");
        }

        public void AddEnd(int roll, string name, int age, char grade)
        {
            StudentNode newNode = new StudentNode(roll, name, age, grade);
            if (head == null) { head = newNode; return; }
            StudentNode temp = head;
            while (temp.Next != null) temp = temp.Next;
            temp.Next = newNode;
            Console.WriteLine("Success: Student added at the end.");
        }

        public void AddAtPosition(int pos, int roll, string name, int age, char grade)
        {
            if (pos <= 1) { AddBeginning(roll, name, age, grade); return; }
            StudentNode newNode = new StudentNode(roll, name, age, grade);
            StudentNode temp = head;
            for (int i = 1; temp != null && i < pos - 1; i++) temp = temp.Next;

            if (temp == null) Console.WriteLine("Position out of range.");
            else
            {
                newNode.Next = temp.Next;
                temp.Next = newNode;
                Console.WriteLine($"Success: Student added at position {pos}.");
            }
        }

        public void Delete(int roll)
        {
            if (head == null) { Console.WriteLine("List is empty."); return; }
            if (head.RollNumber == roll) { head = head.Next; return; }

            StudentNode current = head;
            while (current.Next != null && current.Next.RollNumber != roll)
                current = current.Next;

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                Console.WriteLine("Success: Record deleted.");
            }
            else Console.WriteLine("Error: Roll number not found.");
        }

        public void Search(int roll)
        {
            StudentNode temp = head;
            while (temp != null)
            {
                if (temp.RollNumber == roll)
                {
                    Console.WriteLine($"\n[FOUND] Name: {temp.Name} | Age: {temp.Age} | Grade: {temp.Grade}");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Error: Record not found.");
        }

        public void Update(int roll, char newGrade)
        {
            StudentNode temp = head;
            while (temp != null)
            {
                if (temp.RollNumber == roll)
                {
                    temp.Grade = newGrade;
                    Console.WriteLine("Success: Grade updated.");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Error: Record not found.");
        }

        public void Display()
        {
            if (head == null) { Console.WriteLine("\n--- List is empty ---"); return; }
            StudentNode temp = head;
            Console.WriteLine("\n--- All Student Records ---");
            while (temp != null)
            {
                Console.WriteLine($"ID: {temp.RollNumber} | Name: {temp.Name} | Age: {temp.Age} | Grade: {temp.Grade}");
                temp = temp.Next;
            }
        }
    }
}
