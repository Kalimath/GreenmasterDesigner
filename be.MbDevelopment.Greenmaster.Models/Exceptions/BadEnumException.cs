using System.ComponentModel;

namespace be.MbDevelopment.Greenmaster.Models.Exceptions;

public class BadEnumException : InvalidEnumArgumentException
{
    public BadEnumException()
    {
    }

    public BadEnumException(string? message) : base(message)
    {
    }
}