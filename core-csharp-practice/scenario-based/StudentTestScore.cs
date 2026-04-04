using System;
using System.Runtime.ExceptionServices;
class StudentTestScore
{
    //main method
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the number of students");
        int n = Convert.ToInt32(Console.ReadLine());

        //declaing an array to store the marks
        int[] marks = new int[n];

        //store the score of student in an array
        for(int i = 0; i < n; i++)
        {
            Console.Write("Enter Marks of student "+(i+1)+" = ");
            marks[i] = Convert.ToInt32(Console.ReadLine());
            if (marks[i] < 0)
            {
                Console.Error.WriteLine("!Error! Enter the numaric value !Error!");
                Environment.Exit(1);
            }
            
        }

        StudentTestScore obj = new StudentTestScore();
        obj.Display(marks); //call the display function



    }
    
    //method for display
    void Display(int[] marks)
    {
        StudentTestScore obj = new StudentTestScore();
        double avg = obj.Average(marks);
        while (true) //loop for choice and run until user choice exit
        {
            Console.WriteLine(" press 1 for Average \t press 2 for Highest score \t press 3 for lowest score \t press 4 for above avg marks \t press 5 for Exit ");
            int n = Convert.ToInt32(Console.ReadLine());

            switch (n)
            {
                case 1: // show average marks
                    Console.WriteLine("Average  = "+avg);
                    break;
                case 2: //show highest marks
                    obj.Highest(marks); 
                    break;
                case 3: //show lowest marks
                    obj.Loweset(marks);
                    break;
                case 4: // show all above average marks
                    obj.ShowAboveAverage(avg, marks);
                    break;
                case 5: // exit from programme
                    Environment.Exit(0);
                    break;
                default: // run if user press invalid input
                    Console.WriteLine("Invalid input");
                    break;

            }


        }
    }

    //mehtod for calculating the average marks
    int Average(int[] marks)
    {
        int sum = 0;
        for(int i = 0; i < marks.Length; i++)
        {
            sum += marks[i]; //sum all the marks
        }
        
        return sum/marks.Length; //return the average marks
    }


    //mehthod to find and display the Lowest score.

    void Loweset(int[] marks)
    {
        int lowest = marks[0];
        for(int i = 0;i < marks.Length; i++)
        {
            if (marks[i] <= lowest) // check for the lowest marks
            {
                lowest = marks[i]; 
            }

        }

        Console.WriteLine("The lowest score is = "+lowest); //print the lowest marks
    }


    //method to find the highest score.
    void Highest(int[] marks)
    {
        int highest = 0;
        for(int i =0; i < marks.Length; i++)
        {
            if(marks[i] > highest) //check for highest marks
            {
                highest = marks[i];  
            }
        }

        Console.WriteLine("the highest score is = " + highest); //print higest marks
    }

    //method to display the score above the average
    void ShowAboveAverage(double avg, int[] marks)
    {
        for(int i = 0; i < marks.Length; i++) 
        {
            if (marks[i] > avg) // check if marks above than average or not
            {
                Console.WriteLine("student " + (i + 1) + "having above average marks = " + marks[i]); //print all the marks which is above than average
            }
        }
    }

}