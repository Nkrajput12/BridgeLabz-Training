using System;
class StudentGrades {
    public static void Main(string[]args) {
        Console.Write("Enter Physics marks: "); //taking input physics marks
        int physics = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Chemistry marks: "); //taking input chemistry marks
        int chemistry = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Maths marks: ");  // taking input maths marks
        int maths = Convert.ToInt32(Console.ReadLine());
        double finalAvg = (physics + chemistry + maths) / 3.0;
        Console.WriteLine("Average Mark " + finalAvg);
        if (finalAvg >= 80) {
            Console.WriteLine("Grade Level 4");
            Console.WriteLine("Remarks above agency-normalized standards");
        } 
		else if (finalAvg >= 70) {
            Console.WriteLine("Grade Level 3");
            Console.WriteLine("Remarks at agency-normalized standards");
        } 
		else if (finalAvg >= 60) {
            Console.WriteLine("Grade Level 2");
            Console.WriteLine("Remarks below, but approaching agency-normalized standards");
        } 
		else if (finalAvg >= 50) {
            Console.WriteLine("Grade Level 1");
            Console.WriteLine("Remarks well below agency-normalized standards");
        } 
		else if (finalAvg >= 40) {
            Console.WriteLine("Grade Level 1-");
            Console.WriteLine("Remarks too below agency-normalized standards");
        } 
		else {
            Console.WriteLine("Remarks Remedial standards");
        }
    }
}