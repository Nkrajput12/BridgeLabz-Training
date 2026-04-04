using System;

public class PendingAppointmentException : Exception
{
    public PendingAppointmentException(string message):base(message){}
}