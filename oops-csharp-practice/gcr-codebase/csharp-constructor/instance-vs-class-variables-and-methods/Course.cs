using System;

class Course
{
    // Instance Variables: Unique to each course
    public string courseName;
    public string duration;
    public double fee;

    // Class Variable: All courses belong to the same institute
    public static string instituteName = "Tech Academy";

    public Course(string courseName, string duration, double fee)
    {
        this.courseName = courseName;
        this.duration = duration;
        this.fee = fee;
    }

    // Instance Method: Shows what this specific course is about
    public void DisplayCourseDetails()
    {
        Console.WriteLine($"Course: {courseName} ({duration}) | Fee: {fee} | Institute: {instituteName}");
    }

    // Class Method: Used to rename the institute for everyone at once
    public static void UpdateInstituteName(string newName)
    {
        instituteName = newName;
        Console.WriteLine($"\n[System Message] Institute renamed to: {instituteName}\n");
    }
}

class Application
{
    public static void Main()
    {
        Course c1 = new Course("Data Science", "6 Months", 12000);
        Course c2 = new Course("Web Dev", "3 Months", 8000);

        Console.WriteLine("Before Update:");
        c1.DisplayCourseDetails();
        c2.DisplayCourseDetails();

        // One update changes both objects!
        Course.UpdateInstituteName("Global Tech University");

        Console.WriteLine("After Update:");
        c1.DisplayCourseDetails();
        c2.DisplayCourseDetails();
    }
}