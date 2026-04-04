using System;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.IdentityModel.Tokens;

public class SpecialtyUtility : ISpecialty
{
    public void AddSpecialty()
    {
        ConnectionClass db = new ConnectionClass();
        Console.Write("specialty Name: ");
        string specialty = Console.ReadLine() ?? "";

        using(SqlConnection connect = db.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("sp_AddSpecialty",connect);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SpecialtyName",specialty);

            connect.Open();
            var SpecialtyId = cmd.ExecuteScalar();
            Console.WriteLine("Specialty Add with Id = "+SpecialtyId);

        }
    }
}