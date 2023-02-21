namespace VY.Hackathon.Backend.Domain.Types;

public enum ErrorType
{
    Validation = 400,
    Authorization = 401,
    NotFound = 404,
    Unhandled = 500,
    RepositoryError = 600
}