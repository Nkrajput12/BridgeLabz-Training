using System;

// Interface 
interface IPayable
{
    double CalculateBill();
}

//  Doctor Class
class Doctor
{
    public string doctorName;
    public string specialty;

    public Doctor(string name, string spec)
    {
        doctorName = name;
        specialty = spec;
    }
}

// Base Patient Class 
abstract class Patient : IPayable
{
    public string id;
    public string name;
    public Doctor assignedDoctor;

    public Patient(string id, string name, Doctor doc)
    {
        this.id = id;
        this.name = name;
        this.assignedDoctor = doc;
    }

    // abstract methods
    public abstract void DisplayInfo();
    public abstract double CalculateBill();
}

// In-Patient Class 
class InPatient : Patient
{
    public double rate;
    public int stay;

    public InPatient(string id, string name, Doctor doc, double rate, int days)
        : base(id, name, doc)
    {
        this.rate = rate;
        this.stay = days;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"InPatient: {name} | Doctor: {assignedDoctor.doctorName}");
        Console.WriteLine($"Days Stayed: {stay}");
    }

    public override double CalculateBill() => rate * stay;
}

//Out-Patient Class 
class OutPatient : Patient
{
    public double fee;

    public OutPatient(string id, string name, Doctor doc, double fee)
        : base(id, name, doc)
    {
        this.fee = fee;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"OutPatient: {name} | Doctor: {assignedDoctor.doctorName}");
        Console.WriteLine($"Consultation Fees: ${fee}");
    }

    public override double CalculateBill() => fee;
}

// Bill Class 
class Bill
{
    public static void DisplayBill(Patient p)
    {
        p.DisplayInfo();
        Console.WriteLine("Total Bill Amount: $" + p.CalculateBill());
        Console.WriteLine("-----------------------------");
    }
}

// app Execution class
class App
{
    public static void Main(string[] args)
    {
        Doctor doc = new Doctor("Dr.sonu", "surgen"); //creating object for doctor class

        // Create objects
        InPatient p1 = new InPatient("P1", "Rahul", doc, 500, 3); //method to in patient
        OutPatient p2 = new OutPatient("P2", "Sita", doc, 150); //method to out patient

        // Process Bills
        Bill.DisplayBill(p1); //display the bill details fo p1
        Bill.DisplayBill(p2); // details of p2

    }
}