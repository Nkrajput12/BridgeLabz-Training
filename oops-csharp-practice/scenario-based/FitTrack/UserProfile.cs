using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.FitTrack
{
    public class UserProfile
    {
        private String Name { get; set; }
        private int Age     { get; set; }
        public double Height;
        public double Weight;
        public double TotalCalorieburn = 0;

        public UserProfile(String name, int age, double weight, double height) //constructor to intiallize members
        {
            this.Name = name;
            this.Age = age;
            this.Height = height;
            this.Weight = weight;
        }

        protected void Display() //method to displaay details
        {
            Console.WriteLine($"Name = {Name}\nAge = {Age}\nHeight = {Height}\nWeight = {Weight}\n Total calorie burn = {TotalCalorieburn}");
        }
    }
}
