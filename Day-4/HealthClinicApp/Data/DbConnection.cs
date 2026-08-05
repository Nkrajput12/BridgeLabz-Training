namespace HealthClinic.Data
{
    public static class DbConnection
    {
        public static string GetDbConnection()
        {
            return "Server=localhost;Database=HealthClinic;Integrated Security=True;TrustServerCertificate=True;";
        }
    }
}