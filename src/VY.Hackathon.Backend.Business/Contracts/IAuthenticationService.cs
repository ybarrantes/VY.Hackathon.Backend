using VY.Hackathon.Backend.Domain.Dto;

namespace VY.Hackathon.Backend.Business.Contracts;

public interface IAuthenticationService
{
    Task<string> Register(RegisterRequest request);
    Task<string> Login(LoginRequest request);
}