namespace be.MbDevelopment.Greenmaster.Models.Exceptions;

public class InvalidThresholdsException : ThresholdException
{
    public InvalidThresholdsException()
    {
    }

    public InvalidThresholdsException(string? message) : base(message)
    {
    }
}