using System;
using System.Collections.Generic;

namespace SmartCityTraffic
{
    // OOPS: Entity representing a Vehicle
    public class Vehicle
    {
        public string LicensePlate { get; set; }
        public Vehicle Next { get; set; } // Pointer for Circular Linked List

        public Vehicle(string plate)
        {
            LicensePlate = plate;
        }
    }

    // DSA: Custom Circular Linked List for the Roundabout
    public class Roundabout
    {
        private Vehicle head = null;
        private Vehicle tail = null;
        public int Count { get; private set; } = 0;

        public void Enter(string plate)
        {
            Vehicle newCar = new Vehicle(plate);
            if (head == null)
            {
                head = newCar;
                tail = newCar;
                newCar.Next = head; // Point to self to make it circular
            }
            else
            {
                tail.Next = newCar;
                tail = newCar;
                tail.Next = head; // Link back to start
            }
            Count++;
        }

        public void Exit(string plate)
        {
            if (head == null) return;

            Vehicle current = head;
            Vehicle previous = tail;

            do
            {
                if (current.LicensePlate == plate)
                {
                    if (Count == 1)
                    {
                        head = null;
                        tail = null;
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current == head) head = head.Next;
                        if (current == tail) tail = previous;
                    }
                    Count--;
                    Console.WriteLine($"[EXIT] {plate} has left the roundabout.");
                    return;
                }
                previous = current;
                current = current.Next;
            } while (current != head);

            Console.WriteLine($"[ERR] {plate} not found in roundabout.");
        }

        public void PrintState()
        {
            if (head == null)
            {
                Console.WriteLine("Roundabout is currently empty.");
                return;
            }

            Vehicle temp = head;
            Console.Write("Flow: ");
            do
            {
                Console.Write($"[{temp.LicensePlate}] -> ");
                temp = temp.Next;
            } while (temp != head);
            Console.WriteLine("(Back to start)");
        }
    }

    class TrafficManager
    {
        static void Main(string[] args)
        {
            Roundabout roundabout = new Roundabout();
            Queue<string> entryQueue = new Queue<string>();
            const int MAX_QUEUE = 3;

            while (true)
            {
                Console.WriteLine("\n1. Arrival (Queue) | 2. Enter Roundabout | 3. Exit Roundabout | 4. Show State | 5. Close");
                string cmd = Console.ReadLine();

                if (cmd == "1") // Queue Handling
                {
                    if (entryQueue.Count >= MAX_QUEUE)
                        Console.WriteLine("!!! QUEUE OVERFLOW: Entry road is full.");
                    else
                    {
                        Console.Write("Enter License Plate: ");
                        entryQueue.Enqueue(Console.ReadLine().ToUpper());
                    }
                }
                else if (cmd == "2") // Move from Queue to Circular List
                {
                    if (entryQueue.Count == 0)
                        Console.WriteLine("!!! QUEUE UNDERFLOW: No cars waiting.");
                    else
                        roundabout.Enter(entryQueue.Dequeue());
                }
                else if (cmd == "3") // Remove from Circular List
                {
                    Console.Write("License plate to exit: ");
                    roundabout.Exit(Console.ReadLine().ToUpper());
                }
                else if (cmd == "4")
                {
                    Console.WriteLine($"Waiting in Queue: {entryQueue.Count}");
                    roundabout.PrintState();
                }
                else if (cmd == "5") break;
            }
        }
    }
}