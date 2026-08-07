namespace GreetingApp.Models;

public class NameRepository
{
    private static string _storedName = string.Empty;

    public static void SaveName(string name)
    {
        _storedName = name;
    }

    public static string GetStoredName()
    {
        return _storedName;
    }
}
