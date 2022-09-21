namespace be.MbDevelopment.Greenmaster.Models.Exceptions;

public class ThresholdException : ArgumentException
{
    public ThresholdException()
    {
    }

    public ThresholdException(string? message) : base(message)
    {
    }
}