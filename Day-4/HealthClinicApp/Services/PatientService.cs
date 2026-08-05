using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using HealthClinic.Data;
using HealthClinic.Entities;
using Microsoft.Data.SqlClient;

namespace HealthClinic.Services
{
    public class PatientService
    {
        public void RegisterPatient()
        {
            Patient patient = new Patient();
            string phoneNumber;

            Console.Write("Enter First Name: ");
            patient.FirstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Last Name: ");
            patient.LastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Date of Birth (YYYY-MM-DD): ");
            patient.DateOfBirth = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));

            Console.Write("Enter Gender (M/F/O): ");
            patient.Gender = char.Parse(Console.ReadLine() ?? "M");

            Console.Write("Enter Address: ");
            patient.Address = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Phone Number: ");
            phoneNumber = Console.ReadLine() ?? string.Empty;

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_RegisterPatient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", patient.Gender.ToString());
                    cmd.Parameters.AddWithValue("@Address", patient.Address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", string.IsNullOrWhiteSpace(phoneNumber) ? DBNull.Value : phoneNumber);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("\nPatient registered successfully!");
                    }
                }
            }
        }

        public void UpdatePatient()
        {
            Console.Write("Enter Patient ID to update: ");
            int patientId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter First Name (press Enter to skip): ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Last Name (press Enter to skip): ");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Date of Birth (YYYY-MM-DD) (press Enter to skip): ");
            string dobInput = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Gender (press Enter to skip): ");
            string genderInput = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Address (press Enter to skip): ");
            string address = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Phone Number (press Enter to skip): ");
            string phoneNumber = Console.ReadLine() ?? string.Empty;

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdatePatient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    cmd.Parameters.AddWithValue("@FirstName", string.IsNullOrWhiteSpace(firstName) ? DBNull.Value : firstName);
                    cmd.Parameters.AddWithValue("@LastName", string.IsNullOrWhiteSpace(lastName) ? DBNull.Value : lastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", string.IsNullOrWhiteSpace(dobInput) ? DBNull.Value : DateTime.Parse(dobInput));
                    cmd.Parameters.AddWithValue("@Gender", string.IsNullOrWhiteSpace(genderInput) ? DBNull.Value : genderInput);
                    cmd.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(address) ? DBNull.Value : address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", string.IsNullOrWhiteSpace(phoneNumber) ? DBNull.Value : phoneNumber);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected != 0)
                    {
                        Console.WriteLine("\nPatient updated successfully!");
                    }
                }
            }
        }

        public void DeletePatient()
        {
            Console.Write("Enter Patient ID to delete: ");
            int patientId = int.Parse(Console.ReadLine() ?? "0");

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeletePatient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientID", patientId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected != 0)
                    {
                        Console.WriteLine("\nPatient deleted successfully!");
                    }
                }
            }
        }

        public void ShowAll()
        {
            string query = @"SELECT p.PatientID, p.FirstName, p.LastName, p.DateOfBirth, p.Gender, p.Address, pp.PhoneNumber 
                            FROM Patient p 
                            LEFT JOIN PatientPhone pp ON p.PatientID = pp.PatientID";

            string conn = DbConnection.GetDbConnection();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["PatientID"]},\n Name: {reader["FirstName"]} {reader["LastName"]},\n DOB: {Convert.ToDateTime(reader["DateOfBirth"]):yyyy-MM-dd},\n Gender: {reader["Gender"]},\n Address: {reader["Address"]},\n Phone: {reader["PhoneNumber"]}");
                        Console.WriteLine("\n------------------------------------------------------\n");
                    }
                }
            }
        }

        public void VisitHistory()
        {
            Console.Write("Enter Patient ID to view visit history: ");
            int patientId = int.Parse(Console.ReadLine() ?? "0");

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetPatientAppointmentHistory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientID", patientId);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("\nNo appointment history found for this patient.");
                            return;
                        }

                        Console.WriteLine("\n--- Patient Visit History ---");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Appointment ID: {reader["AppointmentID"]} | Patient: {reader["PatientName"]} \n Doctor: {reader["DoctorName"]} ({reader["Specialization"]}) \n Date: {Convert.ToDateTime(reader["AppointmentDate"]):yyyy-MM-dd} | Time: {reader["TimeSlot"]} \n Status: {reader["Status"]}");
                            Console.WriteLine("\n-------------------------------------------------------\n");
                        }
                    }
                }
            }
        }
    }
}