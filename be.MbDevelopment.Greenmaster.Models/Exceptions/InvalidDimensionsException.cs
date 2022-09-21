namespace be.MbDevelopment.Greenmaster.Models.Exceptions;

public class InvalidDimensionsException : ArgumentException
{
    public InvalidDimensionsException()
    {
    }

    public InvalidDimensionsException(string? message) : base(message)
    {
    }

    public InvalidDimensionsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}