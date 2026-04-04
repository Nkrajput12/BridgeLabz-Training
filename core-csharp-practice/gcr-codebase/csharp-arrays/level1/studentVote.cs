using System;

class StudentVote
    {
        public static void Main(string[] args)
    {   //intiallizing array
        int[] age = new int[10];
            int n = age.Length;
        //taking input
        Console.WriteLine("Enter the age of students");
            for (int i = 0; i < n; i++)
            {
                age[i] = Convert.ToInt32(Console.ReadLine());
            }
        for (int i = 0; i < n; i++)
        {
            if (age[i] > 0)
            {
                if (age[i] >= 18)
                {
                    Console.WriteLine("The student with age " + age[i] + " can vote");
                }
                else
                {
                    Console.WriteLine("The student with age" + age[i]+" cannot vote");
                }
            }
            else
            {
                Console.WriteLine("Invalid age");
            }
        }
       }
   }

