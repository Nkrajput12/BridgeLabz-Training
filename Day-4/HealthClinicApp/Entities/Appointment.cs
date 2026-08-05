using System;

namespace HealthClinic.Entities
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan TimeSlot { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}