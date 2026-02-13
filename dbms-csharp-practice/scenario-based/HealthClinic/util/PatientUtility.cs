using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using Microsoft.IdentityModel.Tokens;


public class PatientUtility : IPatient
{
    ConnectionClass db = new ConnectionClass();
    public void RegisterPatient()
    {
        Console.Write("Enter Full Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter DOB(YYYY-MM-DD)");
        DateTime date = DateTime.Parse(Console.ReadLine() ?? "");

        Console.Write("Enter PhoneNumber: ");
        string Phone = Console.ReadLine() ?? "";

        Console.Write("Enter Email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Enter BloodGroup: ");
        string BloodGroup = Console.ReadLine() ?? "";

        using(SqlConnection connect = db.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("sp_RegisterPatient", connect);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FullName", name);
            cmd.Parameters.AddWithValue("@DOB", date);
            cmd.Parameters.AddWithValue("@Phone",Phone);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@BloodGroup", BloodGroup);

            connect.Open();
            var id = cmd.ExecuteScalar();
            Console.WriteLine("Patient Registered ID "+id);
        }
    }

    public void UpdatePatient()
    {
        Console.WriteLine("Enter Patient ID or PhoneNumber");
        string search = Console.ReadLine() ?? "";
        using(SqlConnection connect = db.GetConnection())
        {
            connect.Open();
            SqlCommand searchcmd = new SqlCommand("sp_GetPatientByIdorPhone",connect);
            searchcmd.CommandType = CommandType.StoredProcedure;

            searchcmd.Parameters.AddWithValue("@SearchTerm",search);

            int foundId = 0;

            using(SqlDataReader rdr = searchcmd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    foundId = (int)rdr["PatientID"];
                    Console.WriteLine("--------CurrentDetails------");
                    Console.WriteLine("ID "+rdr["PatientID"]);
                    Console.WriteLine("Name "+rdr["FullName"]);
                    Console.WriteLine("DOB "+rdr["DOB"]);
                    Console.WriteLine("Phone "+rdr["Phone"]);
                    Console.WriteLine("Email "+rdr["Email"]);
                    Console.WriteLine("BloodGroup "+rdr["BloodGroup"]);
                }
                else
                {
                    Console.WriteLine("No patient Found");
                    return;
                }
            }

            Console.WriteLine("Enter new details:");
            Console.Write("New Name: "); 
            string newName = Console.ReadLine() ?? "";
            Console.Write("NEw DOB(YYYY-MM-DD): ");
            string newDob = Console.ReadLine() ?? "";
            Console.Write("New Phone: "); 
            string newPhone = Console.ReadLine() ?? "";
            Console.Write("New Email: "); 
            string newEmail = Console.ReadLine() ?? "";
            Console.Write("New Blood Group: "); 
            string newBG = Console.ReadLine() ?? "";

            SqlCommand updatecmd = new SqlCommand("sp_UpdatePatient",connect);
            updatecmd.CommandType = CommandType.StoredProcedure;

            updatecmd.Parameters.AddWithValue("@PatientID",foundId);
            updatecmd.Parameters.AddWithValue("@FullName", newName);
            updatecmd.Parameters.AddWithValue("@DOB",newDob);
            updatecmd.Parameters.AddWithValue("@Phone",newPhone);
            updatecmd.Parameters.AddWithValue("@Email",newEmail);
            updatecmd.Parameters.AddWithValue("@BloodGroup",newBG);

            int rowaffect = updatecmd.ExecuteNonQuery();

            if(rowaffect > 0)
            {
                Console.WriteLine("Information Updated");
            }
            else
            {
                Console.WriteLine("Information Not Update");
            }
        }
    }


    public void SearchPatient()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine() ?? "";

        using(SqlConnection connect = db.GetConnection())
        {
            SqlCommand searchcmd = new SqlCommand("sp_SearchPatients", connect);
            searchcmd.CommandType = CommandType.StoredProcedure;

            searchcmd.Parameters.AddWithValue("@Name",name);

            connect.Open();
            using(SqlDataReader reader = searchcmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("--------------Patient ID = "+reader["PatientID"]+"-----------");
                    Console.WriteLine($"Name = {reader["FullName"]} | DOB = {reader["DOB"]}");
                    Console.WriteLine($"Phone = {reader["Phone"]} | Email = {reader["Email"]}");
                    Console.WriteLine($"BloodGroup = {reader["BloodGroup"]}");
                    Console.WriteLine($"------------------------------------------------------");

                }
            }

        }
    }

    public void showAllPatient()
    {
        using(SqlConnection connect = db.GetConnection())
        {
            SqlCommand show = new SqlCommand("sp_ShowAllPatient", connect);
            show.CommandType = CommandType.StoredProcedure;

            connect.Open();
            SqlDataReader reader = show.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Id = "+reader["PatientID"]+"| Name = "+reader["FullName"]+"| DOB = "+reader["DOB"]);
            }
            Console.WriteLine("----------------------------------------------------------------------------");
        }
    }
}