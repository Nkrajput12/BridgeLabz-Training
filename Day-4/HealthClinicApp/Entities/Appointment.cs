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

        public Appointment()
        {
        }

        public Appointment(int appointmentId, int patientId, int doctorId, DateTime appointmentDate, TimeSpan timeSlot, string status)
        {
            AppointmentID = appointmentId;
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = appointmentDate;
            TimeSlot = timeSlot;
            Status = status;
        }
    }
}