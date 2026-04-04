using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    public interface IMedicalRecord
    {
        void AddRecord(string record);
        void ViewRecords();
    }

    
    public abstract class Patient : IMedicalRecord
    {
        
        private int _patientId;
        private string _name;
        private int _age;

        
        private string[] _history;
        private int _recordIndex;

        
        public string Name => _name;
        public int PatientId => _patientId;

        public Patient(int id, string name, int age)
        {
            _patientId = id;
            _name = name;
            _age = age;
            _history = new string[5]; // Stores up to 5 medical notes
            _recordIndex = 0;
        }

        //Shared logic for all patient types
        public void GetPatientDetails()
        {
            Console.WriteLine($"[Patient ID: {_patientId}] Name: {_name}, Age: {_age}");
        }

        // Every patient type calculates billing differently
        public abstract double CalculateBill();

        // Managing medical history manually with an array
        public void AddRecord(string record)
        {
            if (_recordIndex < _history.Length)
            {
                _history[_recordIndex] = record;
                _recordIndex++;
            }
            else
            {
                Console.WriteLine($"History log full for {_name}. Cannot add more records.");
            }
        }

        public void ViewRecords()
        {
            Console.WriteLine($"--- Medical Records for {_name} ---");
            if (_recordIndex == 0)
            {
                Console.WriteLine("No records found.");
            }
            else
            {
                for (int i = 0; i < _recordIndex; i++)
                {
                    Console.WriteLine($"- {_history[i]}");
                }
            }
        }
    }



    // Stays at the hospital, billed by day
    public class InPatient : Patient
    {
        private double _dailyRate;
        private int _stayDuration;

        public InPatient(int id, string name, int age, double dailyRate, int days)
            : base(id, name, age)
        {
            _dailyRate = dailyRate;
            _stayDuration = days;
        }

        // POLYMORPHISM: Unique billing logic for In-Patients
        public override double CalculateBill()
        {
            return _dailyRate * _stayDuration;
        }
    }

    //  Visits for consultation, billed a flat fee
    public class OutPatient : Patient
    {
        private double _flatConsultationFee;

        public OutPatient(int id, string name, int age, double fee)
            : base(id, name, age)
        {
            _flatConsultationFee = fee;
        }

        // Unique billing logic for Out-Patients
        public override double CalculateBill()
        {
            return _flatConsultationFee;
        }
    }

    // --- MAIN PROGRAM ---
    class Program
    {
        static void Main(string[] args)
        {
            // Using an array of the abstract base type
            Patient[] patientRegistry = new Patient[3];

            // Assigning different subclasses to the same array
            patientRegistry[0] = new InPatient(1001, "Amit Sharma", 45, 1500.0, 4);
            patientRegistry[1] = new OutPatient(1002, "Sriya Roy", 29, 850.0);
            patientRegistry[2] = new InPatient(1003, "Vikas Gupta", 62, 1200.0, 2);

            // Adding medical records via the interface method
            patientRegistry[0].AddRecord("Recovering from Appendectomy");
            patientRegistry[0].AddRecord("Post-op checkup normal");
            patientRegistry[1].AddRecord("Prescribed seasonal allergy meds");
            patientRegistry[2].AddRecord("High blood pressure observation");

           
            Console.WriteLine("-------------CITY HOSPITAL MANAGEMENT SYSTEM-------------");
           

            // Loop through the array to show polymorphic behavior
            for (int i = 0; i < patientRegistry.Length; i++)
            {
                if (patientRegistry[i] != null)
                {
                    // Call common concrete method
                    patientRegistry[i].GetPatientDetails();

                    // POLYMORPHISM: The correct CalculateBill is called automatically
                    double billAmount = patientRegistry[i].CalculateBill();
                    Console.WriteLine($"Billing Total: ${billAmount:F2}");

                    // Interface methods
                    patientRegistry[i].ViewRecords();
                    Console.WriteLine(new string('-', 40));
                }
            }

            Console.WriteLine("\nProcessing complete. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
