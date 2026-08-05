using System;

namespace HealthClinic.Entities
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; } = string.Empty;

        public Patient()
        {
        }

        public Patient(int patientId, string firstName, string lastName, DateTime dateOfBirth, char gender, string address)
        {
            PatientID = patientId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
        }
    }
}