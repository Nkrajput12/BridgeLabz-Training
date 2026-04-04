using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;
using Microsoft.Identity.Client;
using System.Security.Cryptography;

public class DoctorUtility : IDoctor
{
    ConnectionClass db = new ConnectionClass();

    // method to add doctor-------------------------------------------------------------------------------------------------------------
    public void AddDoctor()
    {
        Console.Write("Enter Specialty : ");
        string docSpecialty = Console.ReadLine() ?? "";
        
        using(SqlConnection connect = db.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("sp_GetSpecialtyIdByName",connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@specialtyName",docSpecialty);

            connect.Open();
            var Idcheck = cmd.ExecuteScalar();
            
            if(Idcheck == null)
            {
                Console.WriteLine("No ID found with this specialty");
                connect.Close();
                return;
            }
            int Id = (int)Idcheck;
            connect.Close();

            Console.Write("Enter Doctor Name: ");
            string docName = Console.ReadLine() ?? "";

            Console.Write("Enter Fee: ");
            int fee = Convert.ToInt32(Console.ReadLine());


            SqlCommand addcmd = new SqlCommand("sp_AddDoctor",connect);
            addcmd.CommandType = CommandType.StoredProcedure;

            addcmd.Parameters.AddWithValue("@FullName",docName);
            addcmd.Parameters.AddWithValue("@SpecialtyID",Id);
            addcmd.Parameters.AddWithValue("@Fee",fee);

            connect.Open();
            int affect = addcmd.ExecuteNonQuery();
            if(affect > 0)
            {
                Console.WriteLine("Doctor Added successfully");
            }
            else
            {
                Console.WriteLine("Doctor not added");
            }         
        }

    }

    //method to Update Doctor Specialty
    public void UpdateSpecialty()
    {
        using(SqlConnection connect = db.GetConnection())
        {
            SqlCommand showSpecialty = new SqlCommand("sp_DisplaySpecialty",connect);
            showSpecialty.CommandType = CommandType.StoredProcedure;

            connect.Open();
            SqlDataReader reader = showSpecialty.ExecuteReader();
            Console.WriteLine("--------Available Specialty---------");
            while (reader.Read())
            {
                Console.WriteLine("Specialty Id = "+reader["SpecialtyID"]+" | Specialty Name = "+reader["SpecialtyName"]);
            }
            connect.Close();

            Console.Write("Enter Doctor Id: ");
            int docId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new specialty ID: ");
            int newId = Convert.ToInt32(Console.ReadLine());

            SqlCommand updateId = new SqlCommand("sp_UpdateSpecialty",connect);
            updateId.CommandType = CommandType.StoredProcedure;

            updateId.Parameters.AddWithValue("@UpdateID",newId);
            updateId.Parameters.AddWithValue("@DoctorID",docId);
            try
            {
                connect.Open();
                updateId.ExecuteNonQuery();
                Console.WriteLine("successfully Update");
            }
            catch(SqlException ex)
            {
                if(ex.Number == 50001)
                {
                    throw new DoctorIdNotExistException(ex.Message);
                }

                if(ex.Number == 50002)
                {
                    throw new SpecialtyIdNotExistException(ex.Message);
                }
            }
        }
    }

    public void GetDoctorBySpecialty()
    {
        Console.Write("Enter Specialty: ");
        string specialty = Console.ReadLine() ?? "";

        using(SqlConnection connect = db.GetConnection())
        {
            int ID = 0;

            try
            {
                SqlCommand Idcmd = new SqlCommand("sp_GetSpecialtyIdByName",connect);
                Idcmd.CommandType = CommandType.StoredProcedure;

                Idcmd.Parameters.AddWithValue("@specialtyName",specialty);
                connect.Open();
                var idresult = Idcmd.ExecuteScalar();

                if(idresult == null)
                {
                    throw new SpecialtyIdNotExistException("");
                }
                ID = (int)idresult ;
                
                SqlCommand view = new SqlCommand("sp_ViewDoctorBySpecialty",connect);
                view.CommandType = CommandType.StoredProcedure;
                view.Parameters.AddWithValue("SpecialtyID",ID);

                      
                SqlDataReader reader = view.ExecuteReader();

                if (!reader.HasRows)
                {
                    throw new SpecialtyIdNotExistException("");
                }
                while (reader.Read())
                {
                    Console.WriteLine(reader["FullName"]+" | "+reader["SpecialtyName"]);
                }
            
            }
            catch (SqlException ex)
            {
                if(ex.Number == 50002)
                {
                    throw new SpecialtyIdNotExistException(ex.Message);
                }
            }
        
        }
    }

    //method to show all the doctors
    public void ShowAllDoctors()
    {
        using(SqlConnection connect = db.GetConnection())
        {
            SqlCommand show = new SqlCommand("sp_ShowAllDoctor",connect);
            show.CommandType = CommandType.StoredProcedure;

            connect.Open();
            SqlDataReader reader = show.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Id = "+reader["DoctorID"]+" Name = "+reader["FullName"]);
            }
        }
    }

    //method to Deactivate Doctor

    public void DeactivateDoctor()
    {
        try{
            Console.Write("Enter Id: ");
            int docId = Convert.ToInt32(Console.ReadLine());

            using(SqlConnection connect = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_DeactivateDoctor", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorID", docId);

                connect.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected != 0)
                {
                    Console.WriteLine(" Doctor profile deactivated successfully.");
                }
            }
        }
        catch(SqlException ex)
        {
            if (ex.Number == 50001)
            {
                throw new DoctorIdNotExistException(ex.Message);
            }
            else if (ex.Number == 50007)
            {
                throw new PendingAppointmentException(ex.Message);
            }
            
        }
    }
}