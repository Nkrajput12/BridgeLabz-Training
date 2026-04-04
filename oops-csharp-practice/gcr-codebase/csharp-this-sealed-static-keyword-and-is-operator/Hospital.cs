using System;

class Patient
{
    static string HospitalName = "Apollo City Hospital"; // static variable shared among all patients
    private static int totalPatients = 0; // private static variable to track admissions

    public string Name;
    public int Age;
    public string Ailment;
    public readonly string PatientID; // readonly variable for unique identification

    public Patient(string Name, int Age, string Ailment, string PatientID) // constructor to assign values
    {
        this.Name = Name; // using 'this' to refer to the class fields
        this.Age = Age;
        this.Ailment = Ailment;
        this.PatientID = PatientID;
        totalPatients++; // increment the count whenever a new patient is admitted
    }

    public static void GetTotalPatients() // static method to show total patient count
    {
        Console.WriteLine("Total Patients Admitted in " + HospitalName + " = " + totalPatients);
    }

    public void DisplayPatientDetails() // method to display patient info
    {
        Console.WriteLine("Patient ID : " + PatientID);
        Console.WriteLine("Name       : " + Name);
        Console.WriteLine("Age        : " + Age);
        Console.WriteLine("Ailment    : " + Ailment);
        Console.WriteLine("Hospital   : " + HospitalName);
        Console.WriteLine("------------------------------------------");
    }
}

class ApplicationH // application class
{
    public static void Main(string[] args)
    {
        // Creating patient objects
        Patient p1 = new Patient("Amit Sharma", 45, "Fever", "P-1001");
        Patient p2 = new Patient("Sita Verma", 30, "Fracture", "P-1002");

        // Use 'is' operator to check if the objects are instances of Patient class
        if (p1 is Patient && p2 is Patient)
        {
            Console.WriteLine("System Check: Valid Patient records found.");
            Console.WriteLine("------------------------------------------");
            p1.DisplayPatientDetails();
            p2.DisplayPatientDetails();
        }

        // Call the static method using the class name
        Patient.GetTotalPatients();
    }
}