using System;
using Microsoft.Data.SqlClient;
using System.Data;

public class VisitUtility
{
    PatientUtility patient = new PatientUtility();
    ConnectionClass db = new ConnectionClass();
    public void RecordVisit()
{
    try
    {
        Console.Write("Enter Appointment ID: ");
        int apptId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Diagnosis: ");
        string diagnosis = Console.ReadLine() ?? "";
        Console.Write("Notes: ");
        string notes = Console.ReadLine() ?? "";

        
        DataTable prescriptionTable = new DataTable();
        prescriptionTable.Columns.Add("MedicineName", typeof(string));
        prescriptionTable.Columns.Add("Dosage", typeof(string));
        prescriptionTable.Columns.Add("Duration", typeof(string));

        while (true)
        {
            Console.Write("Add Medicine? (y/n): ");
            if (Console.ReadLine()?.ToLower() != "y") break;

            Console.Write("Medicine Name: ");
            string med = Console.ReadLine() ?? "";
            Console.Write("Dosage: ");
            string dose = Console.ReadLine() ?? "";
            Console.Write("Duration: ");
            string dur = Console.ReadLine() ?? "";
            prescriptionTable.Rows.Add(med, dose, dur);
        }

        using (SqlConnection connect = db.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("sp_RecordVisitWithPrescriptions", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ApptID", apptId);
            cmd.Parameters.AddWithValue("@Diagnosis", diagnosis);
            cmd.Parameters.AddWithValue("@Notes", notes);

            
            SqlParameter addpres = cmd.Parameters.AddWithValue("@PrescriptionList", prescriptionTable);
            addpres.SqlDbType = SqlDbType.Structured;
            addpres.TypeName = "PrescriptionType";

            connect.Open();
            var visitId = cmd.ExecuteScalar();
            
            Console.WriteLine($"\n Visit {visitId} recorded.");
            Console.WriteLine(" Status updated to 'COMPLETED'.");
            Console.WriteLine($" {prescriptionTable.Rows.Count} medicines added to prescription.");
        }
    }
    catch (SqlException ex)
    {
        if (ex.Number == 50006) Console.WriteLine("AppointmentIdNotExistException: "+ex.Message);
        Console.WriteLine("Database Error: " + ex.Message);
    }
}

    public void ViewPatientHistory()
    {   
        patient.showAllPatient();
        Console.Write("Select Patient ID from Above to view its history: ");
        int patientId = Convert.ToInt32(Console.ReadLine());

        using(SqlConnection connect = db.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("sp_GetPatientMedicalHistory", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientID", patientId);

            connect.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine($"\n--- Medical History for Patient ID: {patientId} ---");
                Console.WriteLine("---------------------------------------------------------");

                if (!reader.HasRows)
                {
                    Console.WriteLine("No medical history found for this patient.");
                    return;
                }
                while (reader.Read())
                {
                                        
                    Console.WriteLine($"Doctor: {reader["DoctorName"]}");
                    Console.WriteLine($"Diagnosis: {reader["Diagnosis"]}");
                    Console.WriteLine($"Notes: {reader["Notes"]}");
                    Console.WriteLine($"Appt Status: {reader["Status"]}");

                    
                    string medicine = reader["MedicineName"]?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(medicine))
                    {
                        Console.WriteLine($"--> Prescription: {medicine} ({reader["Dosage"]} for {reader["Duration"]})");
                    }
                    else
                    {
                        Console.WriteLine("--> Prescription: None");
                    }

                    Console.WriteLine("---------------------------------------------------------");
                }
            }
        }
    }

    
}
