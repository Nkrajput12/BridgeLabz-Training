using System;

public class InvalidAgeException : Exception
{
    public InvalidAgeException(string msg ) : base(msg){}
}