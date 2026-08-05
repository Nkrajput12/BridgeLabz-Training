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
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count == 0)
                {
                    Console.WriteLine("\nNo audit logs found.");
                    return;
                }

                Console.WriteLine("\n--- Audit Logs ---");
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine($"Audit ID: {row["AuditID"]}\nTable: {row["TableName"]}\nAction: {row["ActionType"]}\nRecord ID: {row["RecordID"]}\nPerformed By: {row["PerformedBy"]}\nDate: {Convert.ToDateTime(row["PerformedAt"]):yyyy-MM-dd HH:mm:ss}\nDetails: {row["Details"]}\n----------------------------------------");
                }
            }
        }
    }
}