using System;
using System.IO;
using Microsoft.Data.SqlClient;

class GenerateReport
{
    static void Main()
    {
        string connString = "Server=myServer;Database=myDB;User Id=myUser;Password=myPassword;";
        string filePath = "EmployeeReport.csv";

        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT EmployeeID, Name, Department, Salary FROM Employees", conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Employee ID,Name,Department,Salary");

                while (reader.Read())
                {
                    sw.WriteLine($"{reader[0]},{reader[1]},{reader[2]},{reader[3]}");
                }
            }
        }
        Console.WriteLine("Report Generated.");
    }
}