namespace be.MbDevelopment.Greenmaster.Models.Exceptions;

public class InvalidRangeException : ArgumentException
{
    public InvalidRangeException()
    {
    }

    public InvalidRangeException(string? message) : base(message)
    {
    }
}