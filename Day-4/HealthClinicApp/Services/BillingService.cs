using System;
using System.Data;
using HealthClinic.Data;
using HealthClinic.Entities;
using Microsoft.Data.SqlClient;

namespace HealthClinic.Services
{
    public class BillingService
    {
        public void GetBillingByPatientID()
        {
            Console.Write("Enter Patient ID: ");
            int patientId = int.Parse(Console.ReadLine() ?? "0");

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetBillingByPatientID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientID", patientId);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("\nNo billing records found for this patient.");
                            return;
                        }

                        Console.WriteLine("\n--- Billing Details ---");
                        while (reader.Read())
                        {
                            string paymentDateStr = reader["PaymentDate"] != DBNull.Value 
                                ? Convert.ToDateTime(reader["PaymentDate"]).ToString("yyyy-MM-dd HH:mm:ss") 
                                : "N/A";

                            Console.WriteLine($"Bill ID: {reader["BillID"]}\nPatient Name: {reader["PatientName"]}\nAmount: {reader["Amount"]}\nPayment Status: {reader["PaymentStatus"]}\nPayment Date: {paymentDateStr}\n----------------------------------------");
                        }
                    }
                }
            }
        }

        public void UpdatePaymentStatus()
        {
            Console.Write("Enter Bill ID: ");
            int billId = int.Parse(Console.ReadLine() ?? "0");

            string str = DbConnection.GetDbConnection();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdatePaymentStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BillID", billId);
                    cmd.Parameters.AddWithValue("@PaymentStatus", "Paid");

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected != 0)
                    {
                        Console.WriteLine("\nPayment status updated to 'Paid' successfully!");
                    }
                }
            }
        }

        public void ShowAll()
        {
            string query = "SELECT * FROM Billing";
            string conn = DbConnection.GetDbConnection();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("\nNo bills found.");
                        return;
                    }

                    Console.WriteLine("\n--- All Bills ---");
                    while (reader.Read())
                    {
                        string paymentDateStr = reader["PaymentDate"] != DBNull.Value 
                            ? Convert.ToDateTime(reader["PaymentDate"]).ToString("yyyy-MM-dd HH:mm:ss") 
                            : "N/A";

                        Console.WriteLine($"Bill ID: {reader["BillID"]}\nAppointment ID: {reader["AppointmentID"]}\nAmount: {reader["Amount"]}\nPayment Status: {reader["PaymentStatus"]}\nPayment Date: {paymentDateStr}\n----------------------------------------");
                    }
                }
            }
        }
    }
}