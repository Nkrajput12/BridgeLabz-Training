using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.StudentManagement_
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentList list = new StudentList();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== STUDENT RECORD SYSTEM ===");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Delete Student");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Grade");
                Console.WriteLine("5. Display All Records");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Roll No: "); int r = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: "); string n = Console.ReadLine();
                        Console.Write("Enter Age: "); int a = int.Parse(Console.ReadLine());
                        Console.Write("Enter Grade (A-F): "); char g = Console.ReadLine()[0];

                        Console.WriteLine("1. Beginning  2. End  3. Specific Position");
                        int sub = int.Parse(Console.ReadLine());
                        if (sub == 1) list.AddBeginning(r, n, a, g);
                        else if (sub == 2) list.AddEnd(r, n, a, g);
                        else
                        {
                            Console.Write("Enter Position: "); int p = int.Parse(Console.ReadLine());
                            list.AddAtPosition(p, r, n, a, g);
                        }
                        break;

                    case 2:
                        Console.Write("Enter Roll Number to Delete: ");
                        list.Delete(int.Parse(Console.ReadLine()));
                        break;

                    case 3:
                        Console.Write("Enter Roll Number to Search: ");
                        list.Search(int.Parse(Console.ReadLine()));
                        break;

                    case 4:
                        Console.Write("Enter Roll Number to Update: ");
                        int uRoll = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Grade: ");
                        char uGrade = Console.ReadLine()[0];
                        list.Update(uRoll, uGrade);
                        break;

                    case 5:
                        list.Display();
                        break;

                    case 6:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
