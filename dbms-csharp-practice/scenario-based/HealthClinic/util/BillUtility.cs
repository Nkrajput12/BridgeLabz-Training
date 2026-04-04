using System;
using Microsoft.Data.SqlClient;
using System.Data;

public class BillUtility : IBill
{
    ConnectionClass db = new ConnectionClass();

    public void GenerateBill()
    {
    
        Console.Write("Enter Visit ID to Generate Bill: ");
        if (!int.TryParse(Console.ReadLine(), out int visitId)) return;

        Console.Write("Enter Additional Charges (e.g., Medicine/Tests): ");
        decimal additional = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Is payment received now? (Y/N): ");
        string paidResponse = Console.ReadLine()?.ToUpper() ?? "";
        string status = (paidResponse == "Y") ? "PAID" : "UNPAID";

        Console.Write("Enter Payment Mode (Cash/Card/Online): ");
        string mode = Console.ReadLine() ?? "Cash";

        using (SqlConnection connect = db.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("sp_GenerateBill", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VisitID", visitId);
            cmd.Parameters.AddWithValue("@AdditionalCharges", additional);
            cmd.Parameters.AddWithValue("@PaymentMode", mode);
            cmd.Parameters.AddWithValue("@Status",status);

            connect.Open();
            
            
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                Console.WriteLine("\n===============================");
                Console.WriteLine("       BILL GENERATED          ");
                Console.WriteLine("===============================");
                Console.WriteLine($"Visit ID: {visitId}");
                Console.WriteLine($"Total Amount Paid: {result}");
                Console.WriteLine($"Payment Mode: {mode}");
                Console.WriteLine($"Status: {status}");
                Console.WriteLine("===============================");
            }
        }
    
    }

 public void ViewOutstandingBills()
{
    using (SqlConnection connect = db.GetConnection())
    {
        
        string sql = @"
            SELECT P.FullName, COUNT(B.BillID) as UnpaidCount, SUM(B.TotalAmount) as TotalOwed
            FROM Bills B
            JOIN Visits V ON B.VisitID = V.VisitID
            JOIN Appointments A ON V.AppointmentID = A.AppointmentID
            JOIN Patients P ON A.PatientID = P.PatientID
            WHERE UPPER(TRIM(B.PaymentStatus)) = 'UNPAID'
            GROUP BY P.FullName";

        SqlCommand cmd = new SqlCommand(sql, connect);
        try {
            connect.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n--- OUTSTANDING BILLS REPORT ---");
            
            if (!reader.HasRows) {
                Console.WriteLine("No outstanding payments found. All accounts are clear!");
            }

            while (reader.Read())
            {
                string name = reader["FullName"].ToString()??"";
                string count = reader["UnpaidCount"].ToString()??"";
                // Formatting as Currency
                string owed = string.Format("{0:C}", reader["TotalOwed"]);
                
                Console.WriteLine($"Patient: {name} | Bills: {count} | Total Owed: {owed}");
            }
        }
        catch (Exception ex) {
            Console.WriteLine("Report Error: " + ex.Message);
        }
    }
}

    public void GenerateRevenueReport()
    {
        using(SqlConnection connect = db.GetConnection())
        {
            string sql = @"SELECT 
                            d.FullName AS DoctorName,
                            s.SpecialtyName,
                            SUM(b.TotalAmount) AS TotalRevenue
                            FROM Doctors d
                            JOIN Specialties s ON d.SpecialtyID = s.SpecialtyID
                            JOIN Appointments a ON d.DoctorID = a.DoctorID
                            JOIN Visits v ON a.AppointmentID = v.AppointmentID
                            JOIN Bills b ON v.VisitID = b.VisitID
                            GROUP BY d.FullName, s.SpecialtyName
                            ORDER BY TotalRevenue DESC;";

            SqlCommand cmd = new SqlCommand(sql,connect);

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine(" DoctorName  |  Specialty Name  | TotalRevenue ");
                while(reader.Read())
                {
                    Console.WriteLine($"{reader["DoctorName"]} | {reader["specialtyName"]}       | {reader["TotalRevenue"]}");
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


public void ProcessOutstandingPayment()
{
    Console.Write("\nEnter Bill ID to Pay: ");
    if (!int.TryParse(Console.ReadLine(), out int billId)) return;

    using (SqlConnection connect = db.GetConnection())
    {
        
        string checkSql = "SELECT TotalAmount, PaymentStatus FROM Bills WHERE BillID = @id";
        SqlCommand checkCmd = new SqlCommand(checkSql, connect);
        checkCmd.Parameters.AddWithValue("@id", billId);

        
            connect.Open();
            SqlDataReader reader = checkCmd.ExecuteReader();

            if (reader.Read())
            {
                string status = reader["PaymentStatus"].ToString() ?? "";
                decimal amount = Convert.ToDecimal(reader["TotalAmount"]);

                if (status.ToUpper() == "PAID")
                {
                    Console.WriteLine(" This bill is already PAID.");
                    return;
                }

                reader.Close(); 

                //Process the Payment
                Console.WriteLine($"Total Due: {amount}");
                Console.Write("Enter Payment Mode (Cash/Card/Online): ");
                string mode = Console.ReadLine() ?? "Cash";

                string updateSql = @"UPDATE Bills 
                                    SET PaymentStatus = 'PAID', 
                                        PaymentMode = @mode, 
                                        PaymentDate = GETDATE() 
                                    WHERE BillID = @id";
                
                SqlCommand updateCmd = new SqlCommand(updateSql, connect);
                updateCmd.Parameters.AddWithValue("@mode", mode);
                updateCmd.Parameters.AddWithValue("@id", billId);

                int rows = updateCmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine("\n Payment Successful! Bill marked as PAID.");
                }
            }
            else
            {
                Console.WriteLine(" Bill ID not found.");
            }
        
        
    }
}
}