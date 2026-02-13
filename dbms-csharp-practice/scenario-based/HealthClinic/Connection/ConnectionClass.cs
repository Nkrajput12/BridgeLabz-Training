using System;
using Microsoft.Data.SqlClient;

public class ConnectionClass
{
    string ConnectionString = "Server = localhost; DataBase = HealthClinicDB; Integrated Security = True; TrustServerCertificate=True;";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}