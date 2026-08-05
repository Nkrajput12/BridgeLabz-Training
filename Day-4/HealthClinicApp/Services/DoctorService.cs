using System;
using System.Data;
using HealthClinic.Data;
using HealthClinic.Entities;
using Microsoft.Data.SqlClient;

namespace HealthClinic.Services
{
    public class DoctorService
    {
        public void AddDoctor()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Specialization: ");
            string specialization = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Consultation Fee: ");
            decimal consultationFee = decimal.Parse(Console.ReadLine() ?? "500");

            Console.Write("Enter Room ID: ");
            int roomId = int.Parse(Console.ReadLine() ?? "0");

            Doctor doctor = new Doctor(0, firstName, lastName, specialization, phone, roomId, consultationFee);

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_RegisterDoctor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
                    cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                    cmd.Parameters.AddWithValue("@Phone", doctor.Phone);
                    cmd.Parameters.AddWithValue("@ConsultationFee", doctor.ConsultationFee);
                    cmd.Parameters.AddWithValue("@RoomID", doctor.RoomId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected != 0)
                    {
                        Console.WriteLine("\nDoctor registered successfully!");
                    }
                }
            }
        }

        public void UpdateDoctor()
        {
            Console.Write("Enter Doctor ID to update: ");
            int doctorId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter First Name (press Enter to skip): ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Last Name (press Enter to skip): ");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Specialization (press Enter to skip): ");
            string specialization = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Phone (press Enter to skip): ");
            string phone = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Consultation Fee (press Enter to skip): ");
            string feeInput = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Room ID (press Enter to skip): ");
            string roomIdInput = Console.ReadLine() ?? string.Empty;

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateDoctor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                    cmd.Parameters.AddWithValue("@FirstName", string.IsNullOrWhiteSpace(firstName) ? DBNull.Value : firstName);
                    cmd.Parameters.AddWithValue("@LastName", string.IsNullOrWhiteSpace(lastName) ? DBNull.Value : lastName);
                    cmd.Parameters.AddWithValue("@Specialization", string.IsNullOrWhiteSpace(specialization) ? DBNull.Value : specialization);
                    cmd.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(phone) ? DBNull.Value : phone);
                    cmd.Parameters.AddWithValue("@ConsultationFee", string.IsNullOrWhiteSpace(feeInput) ? DBNull.Value : decimal.Parse(feeInput));
                    cmd.Parameters.AddWithValue("@RoomID", string.IsNullOrWhiteSpace(roomIdInput) ? DBNull.Value : int.Parse(roomIdInput));

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    
                        Console.WriteLine("\nDoctor updated successfully!");
                    
                }
            }
        }

        public void DeleteDoctor()
        {
            Console.Write("Enter Doctor ID to delete: ");
            int doctorId = int.Parse(Console.ReadLine() ?? "0");

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteDoctor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DoctorID", doctorId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected != 0)
                    {
                        Console.WriteLine("\nDoctor deleted successfully!");
                    }
                }
            }
        }

        public void ShowAll()
        {
            string query = "Select * from Doctor";
            string conn = DbConnection.GetDbConnection();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["DoctorID"]},\n Name: Dr. {reader["FirstName"]} {reader["LastName"]},\n Specialization: {reader["Specialization"]},\n Phone: {reader["Phone"]},\n Fee: {reader["ConsultationFee"]},\n Room ID: {reader["RoomID"]}");
                        Console.WriteLine("\n-------------------------------------------------------\n");
                    }
                }
            }
        }
    }
}