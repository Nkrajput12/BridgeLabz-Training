using System;
using System.Data;
using HealthClinic.Data;
using HealthClinic.Entities;
using Microsoft.Data.SqlClient;

namespace HealthClinic.Services
{
    public class AppointmentService
    {
        public void BookAppointment()
        {
            Appointment appointment = new Appointment();

            Console.Write("Enter Patient ID: ");
            appointment.PatientId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Doctor ID: ");
            appointment.DoctorId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Appointment Date (YYYY-MM-DD): ");
            appointment.AppointmentDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));

            Console.Write("Enter Time Slot (HH:MM:SS): ");
            appointment.TimeSlot = TimeSpan.Parse(Console.ReadLine() ?? "09:00:00");

            Console.Write("Enter Status (press Enter for default 'Scheduled'): ");
            string statusInput = Console.ReadLine() ?? string.Empty;
            appointment.Status = string.IsNullOrWhiteSpace(statusInput) ? "Scheduled" : statusInput;

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_BookAppointment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientID", appointment.PatientId);
                    cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorId);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@TimeSlot", appointment.TimeSlot);
                    cmd.Parameters.AddWithValue("@Status", appointment.Status);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected != 0)
                    {
                        Console.WriteLine("\nAppointment booked successfully!");
                    }
                }
            }
        }

        public void UpdateAppointment()
        {
            Console.Write("Enter Appointment ID to update: ");
            int appointmentId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Patient ID (press Enter to skip): ");
            string patientInput = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Doctor ID (press Enter to skip): ");
            string doctorInput = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Appointment Date (YYYY-MM-DD) (press Enter to skip): ");
            string dateInput = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Time Slot (HH:MM:SS) (press Enter to skip): ");
            string timeInput = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Status (press Enter to skip): ");
            string statusInput = Console.ReadLine() ?? string.Empty;

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateAppointment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
                    cmd.Parameters.AddWithValue("@PatientID", string.IsNullOrWhiteSpace(patientInput) ? DBNull.Value : int.Parse(patientInput));
                    cmd.Parameters.AddWithValue("@DoctorID", string.IsNullOrWhiteSpace(doctorInput) ? DBNull.Value : int.Parse(doctorInput));
                    cmd.Parameters.AddWithValue("@AppointmentDate", string.IsNullOrWhiteSpace(dateInput) ? DBNull.Value : DateTime.Parse(dateInput));
                    cmd.Parameters.AddWithValue("@TimeSlot", string.IsNullOrWhiteSpace(timeInput) ? DBNull.Value : TimeSpan.Parse(timeInput));
                    cmd.Parameters.AddWithValue("@Status", string.IsNullOrWhiteSpace(statusInput) ? DBNull.Value : statusInput);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected != 0)
                    {
                        Console.WriteLine("\nAppointment updated successfully!");
                    }
                }
            }
        }

        public void CancelAppointment()
        {
            Console.Write("Enter Appointment ID to cancel: ");
            int appointmentId = int.Parse(Console.ReadLine() ?? "0");

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CancelAppointment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected != 0)
                    {
                        Console.WriteLine("\nAppointment cancelled successfully!");
                    }
                }
            }
        }

        public void ShowAll()
        {
            string query = "SELECT * FROM Appointment";
            string conn = DbConnection.GetDbConnection();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("\nNo appointments found.");
                        return;
                    }

                    Console.WriteLine("\n--- All Appointments ---");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Appointment ID: {reader["AppointmentID"]}\nPatient ID: {reader["PatientID"]}\nDoctor ID: {reader["DoctorID"]}\nDate: {Convert.ToDateTime(reader["AppointmentDate"]):yyyy-MM-dd}\nTime Slot: {reader["TimeSlot"]}\nStatus: {reader["Status"]}\n----------------------------------------");
                    }
                }
            }
        }
    }
}