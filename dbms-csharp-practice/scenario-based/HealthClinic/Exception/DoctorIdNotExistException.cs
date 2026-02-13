using System;

public class DoctorIdNotExistException : Exception
{
    public DoctorIdNotExistException(string message):base(message){}
}