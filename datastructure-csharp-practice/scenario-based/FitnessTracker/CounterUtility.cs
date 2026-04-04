using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.FitnessTracker
{
    internal class CounterUtility
    {
        Customer[] customers = new Customer[20];
        int count = 0;

        //method to add customer
        public void AddCustomer() { 
            

            if(count == customers.Length)
            {
                Console.WriteLine("capacity full");
            }
            Console.WriteLine("Enter Customer Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Customer Age: ");
            int age = Convert.ToInt32(Console.ReadLine());


            customers[count] = new Customer(name, age);
            count++;

            Console.WriteLine("Customer added successfully-------------");
        }
        

        //method to generate count to all costumer
        public void GenerateStep()
        {
            Random rnd = new Random();
            
            for(int i = 0; i < count; i++)
            {
                int step = rnd.Next(2000, 7001);
                customers[i].StepCount = step;
            }
           
        }

        //method to make leaderboard according to ranking;
        public void DisplayLeaderboard()
        {
            // We only sort the elements that actually contain customer data
            for (int i = 0; i < count-1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    // Bubble Sort: Compare StepCount of adjacent customers
                    // Change '<' to '>' if you want ascending order
                    if (customers[j].StepCount < customers[j + 1].StepCount)
                    {
                        // Swap the customers
                        Customer temp = customers[j];
                        customers[j] = customers[j + 1];
                        customers[j + 1] = temp;
                    }
                }
            }

            // 2. Print the sorted leaderboard
            Console.WriteLine("\n--- Fitness Leaderboard ---");
            Console.WriteLine($"{"Rank",-5} {"Name",-15} {"Steps",-10}");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1,-5} {customers[i].Name,-15} {customers[i].StepCount,-10}");
            }
        }
    }
}
