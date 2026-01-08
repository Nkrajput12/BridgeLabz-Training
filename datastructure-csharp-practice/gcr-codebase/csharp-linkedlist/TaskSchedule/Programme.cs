using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.TaskSchedule
{
    class Program
    {
        static void Main()
        {
            TaskScheduler scheduler = new TaskScheduler();
            while (true)
            {
                Console.WriteLine("\n CIRCULAR TASK SCHEDULER");
                Console.WriteLine("1. Add Task\n2. Remove Task\n3. Next Task (Cycle)\n4. Search by Priority\n5. View All Tasks\n6. Exit");
                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();

                if (choice == "6") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("Task ID: "); int id = int.Parse(Console.ReadLine());
                        Console.Write("Name: "); string name = Console.ReadLine();
                        Console.Write("Priority (High/Med/Low): "); string prio = Console.ReadLine();
                        Console.Write("Due Date: "); string date = Console.ReadLine();
                        Console.WriteLine("1. Beginning  2. End");
                        if (Console.ReadLine() == "1") scheduler.AddBeginning(id, name, prio, date);
                        else scheduler.AddEnd(id, name, prio, date);
                        break;

                    case "2":
                        Console.Write("Enter Task ID to remove: ");
                        scheduler.RemoveTask(int.Parse(Console.ReadLine()));
                        break;

                    case "3":
                        scheduler.ViewNextTask();
                        break;

                    case "4":
                        Console.Write("Enter Priority: ");
                        scheduler.SearchByPriority(Console.ReadLine());
                        break;

                    case "5":
                        scheduler.DisplayAll();
                        break;

                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }
    }
}
