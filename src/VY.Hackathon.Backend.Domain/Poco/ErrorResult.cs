namespace VY.Hackathon.Backend.Domain.Poco;

public record ErrorResult
{
    public ErrorResult(string message)
    {
        Message = message;
    }
    
    public ErrorResult(string message, string code)
        : this(message)
    {
        Code = code;
    }
    
    public string Code { get; }
    public string Message { get; }
}