using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.FitTrack
{
    internal class FitnessTracker
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--------------Fitness Tracker System-----------------");
            //Taking User Input
            Console.Write("Enter Name = ");
            string name = Console.ReadLine(); //name
            Console.Write("\nEnter age = ");
            int age = int.Parse(Console.ReadLine()); //age
            Console.Write("\nEnter height in cm = ");
            double height = double.Parse(Console.ReadLine()); //height
            Console.Write("\nEnter Weight in kg = ");
            double weight = double.Parse(Console.ReadLine()); //weight

            Workout workout = new Workout(name, age,weight,height); //creating and intiallizing the workout object
            
            bool exit = false;
            while (!exit)
            {
                //promt for choice
                Console.WriteLine("Press 1 for cardio Workout");
                Console.WriteLine("Press 2 for Strength Workout");
                Console.WriteLine("Press 3 for Display Details");
                Console.WriteLine("press 4 for Exit");
                Console.Write("input here : ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        workout.CardioWorkout(); //call method for cardio
                        break;

                    case 2:
                        workout.StrengthWorkout(); //call method for strength
                        break;

                    case 3:
                        workout.Display(); // display method
                        break;

                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
