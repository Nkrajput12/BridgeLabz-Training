using System;

public class SpecialtyIdNotExistException : Exception
{
    public SpecialtyIdNotExistException(string message):base(message){}
}