using System;
using Microsoft.Data.SqlClient;
using System.Data;

public class AdminUtility
{
    ConnectionClass db = new ConnectionClass();
    public void ShowAuditLogs()
{
    Console.WriteLine("\n--- System Audit Filter ---");
    Console.Write("Filter by Table Name (or leave blank for all): ");
    string tableName = Console.ReadLine() ?? "";

    Console.Write("Filter by Action (INSERT/UPDATE/DELETE or blank): ");
    string action = Console.ReadLine() ?? "";

    using (SqlConnection connect = db.GetConnection())
    {
        
        string sql = @"
            SELECT LogID, TableName, ActionType, ActionTimestamp, RecordID 
            FROM audit_log 
            WHERE (@Table = '' OR TableName = @Table) 
            AND (@Action = '' OR ActionType = @Action)
            ORDER BY ActionTimestamp DESC";

        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.AddWithValue("@Table", tableName);
        cmd.Parameters.AddWithValue("@Action", action);

        try
        {
            connect.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nID | Table      | Action | Timestamp           | Record ID");
            Console.WriteLine("----------------------------------------------------------");

            if (!reader.HasRows)
            {
                Console.WriteLine("No logs found matching those criteria.");
            }

            while (reader.Read())
            {
                Console.WriteLine($"{reader["LogID"],-2} | " +
                                  $"{reader["TableName"],-10} | " +
                                  $"{reader["ActionType"],-6} | " +
                                  $"{reader["ActionTimestamp"],-19} | " +
                                  $"{reader["RecordID"]}");
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Database Error: " + ex.Message);
        }
    }
}

public void BackupPatientData()
{
    string folderPath = @"C:\Users\nkr88\OneDrive\Desktop\New folder"; 
    string fileName = $"HealthClinic_{DateTime.Now:yyyyMMdd_HHmm}.bak";
    string fullPath = System.IO.Path.Combine(folderPath, fileName);

    if (!System.IO.Directory.Exists(folderPath))
        System.IO.Directory.CreateDirectory(folderPath);

    using (SqlConnection connect = db.GetConnection())
    {
        
        string sql = "BACKUP DATABASE [HealthClinicDB] TO DISK = @path WITH FORMAT, NAME = 'Full Clinic Backup';";

        SqlCommand cmd = new SqlCommand(sql, connect);
        
        
        cmd.Parameters.AddWithValue("@path", fullPath);

        try
        {
            connect.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine($"\n Database Backup created successfully at: {fullPath}");
        }
        
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
    }
}
}