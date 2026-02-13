using System;
using Microsoft.Data.SqlClient;
using System.Data;

public class AppointmentUtility : IAppointment
{
    ConnectionClass db = new ConnectionClass();

    public void BookAppointment()
    {
        PatientUtility patient = new PatientUtility();
        DoctorUtility doctor = new DoctorUtility();
        patient.showAllPatient();
        Console.Write("\nSelect Patient Id from the above list");
        int id = Convert.ToInt32(Console.ReadLine());

        doctor.ShowAllDoctors();
        Console.WriteLine("\nSelect DoctorId from above list");
        int docId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Date(YYYY-MM-DD): ");
        DateTime date = DateTime.Parse(Console.ReadLine() ?? "");

        Console.Write("Enter Time(HH:MM): ");
        TimeSpan time = TimeSpan.Parse(Console.ReadLine()??"");

        using (SqlConnection connect = db.GetConnection())
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_BookAppointment", connect);
                cmd.CommandType = CommandType.StoredProcedure;

            
                cmd.Parameters.AddWithValue("@PatientID", id);
                cmd.Parameters.AddWithValue("@DoctorID", docId);
                cmd.Parameters.AddWithValue("@ApptDate", date);
                cmd.Parameters.AddWithValue("@ApptTime", time);

                connect.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine(" Appointment scheduled successfully!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50003)
                {
                    Console.WriteLine("AppointmentConflictException: "+ex.Message);
                }
                else
                {
                    Console.WriteLine("General Exception: "+ex.Message);
                }
            }
        }

    }

    public void CheckAvailability()
    {
        Console.Write("Enter Doctor ID: ");
        int docId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Date (YYYY-MM-DD): ");
        DateTime date = DateTime.Parse(Console.ReadLine() ?? "");

        using (SqlConnection connect = db.GetConnection())
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CheckDoctorAvailability", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorID", docId);
                cmd.Parameters.AddWithValue("@ApptDate", date);

                connect.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine($"\n--- Availability for Doctor ID {docId} on {date.ToShortDateString()} ---");
                    Console.WriteLine("Time Slot | Booked | Max | Status");
                    Console.WriteLine("----------------------------------");

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No bookings yet. All slots are available.");
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["ApptTime"]} | " +$"{reader["BookedSlots"]} | " +$"{reader["MaxCapacity"]} | " +$"{reader["SlotStatus"]}");
                                                                                                                
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database Error: " + ex.Message);
            }
        }
    }

    public void CancelAppointment()
    {
        ShowAllAppointment();
        Console.WriteLine("\nSelect Appointment Id from above list");
        int apptId = Convert.ToInt32(Console.ReadLine());

        using (SqlConnection connect = db.GetConnection())
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CancelAppointment", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AppointmentID", apptId);

                connect.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine(" Appointment cancelled successfully.");
                    Console.WriteLine(" Audit log updated automatically by database trigger.");
                }
            }
            catch (SqlException ex)
            {
            
                if (ex.Number == 50006)
                {
                    Console.Write("AppointmentIdNotExistException: "+ex.Message);
                }
                else
                {
                    Console.WriteLine("General Exception: "+ex.Message);
                }
            
            }
        
        }

    }

    public void ShowAllAppointment()
    {
        using(SqlConnection connect = db.GetConnection())
        {
            SqlCommand show = new SqlCommand("sp_ShowAllAppointment",connect);
            show.CommandType = CommandType.StoredProcedure;

            connect.Open();
            SqlDataReader reader = show.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Appointment Id = "+reader["AppointmentID"]+" PatientID = "+reader["PatientID"]);
                Console.WriteLine("Doctor Id = "+reader["DoctorID"]+" Appointment Date = "+reader["ApptDate"]);
                Console.WriteLine("Appointment Time = "+reader["ApptTime"]+" Status = "+reader["Status"]);
                Console.WriteLine("-----------------------------------------------------------------------------------");
            }
        }
    }

    public void RescheduleAppointment()
    {
        ShowAllAppointment();
        Console.Write("\nEnter Appointment ID to Reschedule: ");
        int apptId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Date (YYYY-MM-DD): ");
        DateTime newDate = DateTime.Parse(Console.ReadLine() ?? "");

        Console.Write("Enter New Time (HH:MM): ");
        TimeSpan newTime = TimeSpan.Parse(Console.ReadLine() ?? "");

        Console.Write("Enter New Doctor ID: ");
        int newDocId = Convert.ToInt32(Console.ReadLine());

        using (SqlConnection connect = db.GetConnection())
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_RescheduleAppointment", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AppointmentID", apptId);
                cmd.Parameters.AddWithValue("@NewDate", newDate);
                cmd.Parameters.AddWithValue("@NewTime", newTime);
                cmd.Parameters.AddWithValue("@NewDoctorID", newDocId);

                connect.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected != 0)
                {
                    Console.WriteLine(" Reschedule successful.");
                }
            }
            catch (SqlException ex)
            {
            
                if (ex.Number == 50006)
                {
                    Console.WriteLine("AppointmentIdNotExistException: "+ex.Message);
                }
                else if (ex.Number == 50003)
                {
                    Console.WriteLine("AppointmentConflictException: "+ex.Message);
                }
                else
                {
                    Console.WriteLine("GeneralException: "+ex.Message);
                }
            
            }
        }
    }

}