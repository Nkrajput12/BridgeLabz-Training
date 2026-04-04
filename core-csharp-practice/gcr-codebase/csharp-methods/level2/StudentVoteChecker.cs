using System;
class StudentVoteChecker
{
    //method to check if student is eligible to vote
    public static bool CanStudentVote(int age)
    {
        if (age >= 18)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the number of the student");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] age=new int[number];
        //taking age input for each student
        for(int i=0;i<number;i++)
        {
            Console.WriteLine("student "+(i+1));
            age[i]=Convert.ToInt32(Console.ReadLine());
        }

        //check if the student is eligible to vote
        for(int i=0;i<number;i++)
        {
            bool eligible = CanStudentVote(age[i]);
            if (eligible)
            {
                Console.WriteLine("Student " + (i + 1) + " is eligible to vote");
            }
            else
            {
                Console.WriteLine("Student " + (i + 1) + " is not eligible to vote");
            }
        }
    }
}