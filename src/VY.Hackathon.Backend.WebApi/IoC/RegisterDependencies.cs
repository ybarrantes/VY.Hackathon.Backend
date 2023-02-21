using Microsoft.Extensions.DependencyInjection.Extensions;
using VY.Hackathon.Backend.Business;
using VY.Hackathon.Backend.Business.Contracts;

namespace VY.Hackathon.Backend.WebApi.IoC;

public static class RegisterDependencies
{
    public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IHandlingService, HandlingService>();
        serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
        return serviceCollection;
    } 
}