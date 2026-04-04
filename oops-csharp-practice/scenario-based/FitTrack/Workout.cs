using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.FitTrack
{
    //workout class inherit the interface and userprofile class
    public class Workout : UserProfile, ITrackable
    {
        public Workout(String Name, int age, double weight, double height) : base(Name, age, weight, height) { } //constructor

        Random rand = new Random(); //creating Random class object
        public void CardioWorkout() //method for cardio Workout
        {
            // generate random number for minutes
            int minutes = rand.Next(5, 16);
            double cardiocalorieburn = minutes * 25; //count calorie burn
            Console.WriteLine("\nRunning for " + minutes + "minutes | calorie burn  = " + minutes*25);

            minutes = rand.Next(10, 21);
            cardiocalorieburn += minutes * 15;
            Console.WriteLine("\nJumping Jacks for "+minutes+"minutes | calorie burn = "+minutes*15);

            minutes = rand.Next(2, 9);
            cardiocalorieburn += minutes * 35;
            Console.WriteLine("\nSquat Jumps for " + minutes + "minutes | calorie burn = " + minutes * 35);

            minutes = rand.Next(2, 10);
            cardiocalorieburn += minutes * 10;
            Console.WriteLine("\nHigh Knees for " + minutes + "minutes | calorie burn = " + minutes * 10);

            minutes = rand.Next(20, 31);
            cardiocalorieburn += minutes * 12;
            Console.WriteLine("\nCycling for " + minutes + "minutes | calorie burn = " + minutes * 12);

            Console.WriteLine("------------------------------------------------------------------------------");
            base.TotalCalorieburn += cardiocalorieburn; //calorie burn add in base class Total calorie burn
            Console.WriteLine("Total calorie burn during cardio Workout = " + cardiocalorieburn);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        public void StrengthWorkout()
        {
            //generate random nuber for repitation
            int repitation = rand.Next(20, 31);
            double strengthcalorieburn = repitation * 35;
            Console.WriteLine($"\nPush Ups {repitation} reps | calorie burn = {repitation * 35}");

            repitation = rand.Next(15, 25);
            strengthcalorieburn += repitation * 25;
            Console.WriteLine($"\nlunges {repitation} reps | calorie burn = {repitation * 25}");

            repitation = rand.Next(15, 21);
            strengthcalorieburn += repitation * 55;
            Console.WriteLine($"\nBench Press {repitation} reps | calorie burn = {repitation * 55}");

            repitation = rand.Next(15, 21);
            strengthcalorieburn += repitation * 35;
            Console.WriteLine($"\nPull-ups {repitation} reps | calorie burn = {repitation * 35}");

            repitation = rand.Next(25, 31);
            strengthcalorieburn += repitation * 45;
            Console.WriteLine($"\nOverhead Press {repitation} reps | calorie burn = {repitation * 45}");

            Console.WriteLine("-----------------------------------------------------------------------");
            base.TotalCalorieburn += strengthcalorieburn;
            Console.WriteLine("Total calorie burn during Strength Workout = " + strengthcalorieburn);
            Console.WriteLine("------------------------------------------------------------------------");

        }

        //method to display the details
        public void Display()
        {
            base.Display(); //calling base class display method.
        }

    }
}
