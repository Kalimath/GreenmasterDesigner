namespace be.MbDevelopment.Greenmaster.Models.Exceptions;

public class InValidPathShapeException : ArgumentOutOfRangeException
{
    public InValidPathShapeException(string? paramName, object? actualValue, string? message) : base(paramName, actualValue, message)
    {
    }

    public InValidPathShapeException(string? paramName, string? message) : base(paramName, message)
    {
    }
}