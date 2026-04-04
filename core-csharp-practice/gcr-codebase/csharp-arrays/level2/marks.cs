using System;
class Marks
{
    public static void Main(string[] args)
    {
        //taking input from user
        Console.WriteLine("Enter the number of students");
        int students = Convert.ToInt32(Console.ReadLine());
        //creating arrays to store marks of subjects
        int[] physics = new int[students];
        int[] chemistry = new int[students];
        int[] maths = new int[students];

        int[] percentage = new int[students];

        //taking input for marks
        for (int i = 0; i < students; i++)
        {
            Console.WriteLine("Enter marks for student " + (i + 1));
            Console.Write("Physics: ");
            physics[i] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Chemistry: ");
            chemistry[i] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Maths: ");
            maths[i] = Convert.ToInt32(Console.ReadLine());
        }
        //calculating percentage
        for (int i = 0; i < students; i++)
        {
            percentage[i] = (physics[i] + chemistry[i] + maths[i]) / 3;
        }
        string[] grades = new string[students];
        string[] remark = new string[students];
        //computing grades and remarks

        for (int i = 0; i < students; i++)
        {
            if (percentage[i] >= 80)
            {
                grades[i] = "A";
                remark[i] = "(Level 4,above agency-normalized standards)";
            }
            else if (percentage[i] >= 70 && percentage[i] < 80)
            {
                grades[i] = "B";
                remark[i] = "(Level 3, at agency-normalized standards)";
            }
            else if (percentage[i] >= 60 && percentage[i] < 70)
            {
                grades[i] = "C";
                remark[i] = "(Level 2, below, but approaching agency-normalized standards)";
            }
            else if (percentage[i] >= 50 && percentage[i] < 60)
            {
                grades[i] = "D";
                remark[i] = "(Level 1, well below agency-normalized standards)";
            }
            else if (percentage[i] >= 40 && percentage[i] < 50)
            {
                grades[i] = "E";
                remark[i] = "(Level 1, too below agency-normalized standards)";
            }
            else
            {
                grades[i] = "R";
                remark[i] = "(Remedial standards)";
            }
        }

            //print the results 
            for(int i=0; i<students; i++)
            {
                Console.WriteLine("For student " + (i + 1) + " Physics = " + physics[i] + ", Chemistry = " + chemistry[i] + ", Maths = " + maths[i] + ", Percentage = " + percentage[i] + ", Grade = " + grades[i] + " " + remark[i]);
            }
        }
    }
