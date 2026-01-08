using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.TaskSchedule
{
    public class TaskScheduler
    {
        private TaskNode tail = null;
        private TaskNode currentTask = null; // To track "Move to Next" functionality

        //Add Task
        public void AddBeginning(int id, string name, string priority, string date)
        {
            TaskNode newNode = new TaskNode(id, name, priority, date);
            if (tail == null)
            {
                tail = newNode;
                tail.Next = tail; // Points to itself
            }
            else
            {
                newNode.Next = tail.Next;
                tail.Next = newNode;
            }
            Console.WriteLine("Task added at the start.");
        }

        public void AddEnd(int id, string name, string priority, string date)
        {
            TaskNode newNode = new TaskNode(id, name, priority, date);
            if (tail == null)
            {
                tail = newNode;
                tail.Next = tail;
            }
            else
            {
                newNode.Next = tail.Next;
                tail.Next = newNode;
                tail = newNode; // Move tail to the new last node
            }
            Console.WriteLine("Task added at the end.");
        }

        //Remove Task by ID
        public void RemoveTask(int id)
        {
            if (tail == null) return;

            TaskNode curr = tail.Next; // Head
            TaskNode prev = tail;

            do
            {
                if (curr.TaskID == id)
                {
                    if (curr == tail && curr.Next == tail) // Only one node in list
                    {
                        tail = null;
                        currentTask = null;
                    }
                    else
                    {
                        prev.Next = curr.Next;
                        if (curr == tail) tail = prev;
                        if (curr == currentTask) currentTask = curr.Next;
                    }
                    Console.WriteLine($"Task {id} removed.");
                    return;
                }
                prev = curr;
                curr = curr.Next;
            } while (curr != tail.Next);

            Console.WriteLine("Task ID not found.");
        }

        // Move to Next Task
        public void ViewNextTask()
        {
            if (tail == null) { Console.WriteLine("No tasks scheduled."); return; }

            if (currentTask == null) currentTask = tail.Next; // Start at head
            else currentTask = currentTask.Next; // Move to next in circle

            Console.WriteLine($"\n>>> CURRENT TASK: [{currentTask.TaskID}] {currentTask.TaskName}");
            Console.WriteLine($"Priority: {currentTask.Priority} | Due: {currentTask.DueDate}");
        }

        // Search by Priority
        public void SearchByPriority(string priority)
        {
            if (tail == null) return;
            TaskNode temp = tail.Next;
            bool found = false;
            do
            {
                if (temp.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"[{temp.TaskID}] {temp.TaskName} - Due: {temp.DueDate}");
                    found = true;
                }
                temp = temp.Next;
            } while (temp != tail.Next);

            if (!found) Console.WriteLine($"No tasks found with {priority} priority.");
        }

        // Display All
        public void DisplayAll()
        {
            if (tail == null) { Console.WriteLine("Scheduler is empty."); return; }
            TaskNode temp = tail.Next;
            Console.WriteLine("\n--- All Tasks (Circular Loop) ---");
            do
            {
                string marker = (temp == currentTask) ? " (Active) " : "";
                Console.WriteLine($"{marker}[{temp.TaskID}] {temp.TaskName} | {temp.Priority} | {temp.DueDate}");
                temp = temp.Next;
            } while (temp != tail.Next);
        }
    }
}
