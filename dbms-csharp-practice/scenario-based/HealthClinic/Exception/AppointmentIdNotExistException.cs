using System;

public class AppointmentIdNotExistException : Exception
{
    public AppointmentIdNotExistException(string message): base(message){}
}