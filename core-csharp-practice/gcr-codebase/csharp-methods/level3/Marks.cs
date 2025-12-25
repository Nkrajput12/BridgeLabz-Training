using System;
class Marks
{
    
    //method for generating random 2digit marks for physics,chemistry,maths
    public static int[,] GenerateMarks(int numberOfStudents)
    {
        Random rand = new Random();
        int[,] marks = new int[numberOfStudents, 3];
        for (int i = 0; i < numberOfStudents; i++)
        {
            marks[i, 0] = rand.Next(0, 101); // Physics
            marks[i, 1] = rand.Next(0, 101); // Chemistry
            marks[i, 2] = rand.Next(0, 101); // Maths
        }
        return marks;
    }

    // Method to calculate the total, average, and percentages for each student
    public static (int[] totals, double[] averages, double[] percentages) CalculateResults(int[,] marks)
    {
        int numberOfStudents = marks.GetLength(0);
        int[] totals = new int[numberOfStudents];
        double[] averages = new double[numberOfStudents];
        double[] percentages = new double[numberOfStudents];
        for (int i = 0; i < numberOfStudents; i++)
        {
            totals[i] = marks[i, 0] + marks[i, 1] + marks[i, 2];
            averages[i] = totals[i] / 3.0;
            percentages[i] = (totals[i] / 300.0) * 100;
        }
        return (totals, averages, percentages);
    }

    //method to display the scorecard/t
    public static void DisplayScorecard(int[,] marks, int[] totals, double[] averages, double[] percentages)
    {
        Console.WriteLine("Student\tPhysics\tChemistry\tMaths\tTotal\tAverage\tPercentage");
        for (int i = 0; i < marks.GetLength(0); i++)
        {
            Console.WriteLine($"{i + 1}\t{marks[i, 0]}\t{marks[i, 1]}\t\t{marks[i, 2]}\t{totals[i]}\t{averages[i]:F2}\t{percentages[i]:F2}%");
        }
    }

    public static void Main(string[] args)
    {
        int numberOfStudents = 10;
        int[,] marks = GenerateMarks(numberOfStudents);
        var (totals, averages, percentages) = CalculateResults(marks);
        DisplayScorecard(marks, totals, averages, percentages);
    }
}