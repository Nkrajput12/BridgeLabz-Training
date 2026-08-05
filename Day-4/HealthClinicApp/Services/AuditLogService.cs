using System;
using System.Data;
using HealthClinic.Data;
using Microsoft.Data.SqlClient;

namespace HealthClinic.Services
{
    public class AuditLogService
    {
        public void ShowAll()
        {
            string query = "SELECT * FROM AuditLog";
            string conn = DbConnection.GetDbConnection();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("\nNo audit logs found.");
                        return;
                    }

                    Console.WriteLine("\n--- Audit Logs ---");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Audit ID: {reader["AuditID"]}\nTable: {reader["TableName"]}\nAction: {reader["ActionType"]}\nRecord ID: {reader["RecordID"]}\nPerformed By: {reader["PerformedBy"]}\nDate: {Convert.ToDateTime(reader["PerformedAt"]):yyyy-MM-dd HH:mm:ss}\nDetails: {reader["Details"]}\n----------------------------------------");
                    }
                }
            }
        }
    }
}