using VY.Hackathon.Backend.Business;
using VY.Hackathon.Backend.Business.Contracts;
using VY.Hackathon.Backend.Domain.Repository;
using VY.Hackathon.Backend.Repository.Repositories;

namespace VY.Hackathon.Backend.WebApi.IoC;

public static class RegisterDependencies
{
    public static IServiceCollection AddHackathonDependencies(this IServiceCollection serviceCollection)
    {
        RegisterRepositories(serviceCollection);
        RegisterServices(serviceCollection);
        
        return serviceCollection;
    }

    private static void RegisterServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IHandlingService, HandlingService>();
        serviceCollection.AddScoped<ICostService, CostService>();
        serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
    }

    private static void RegisterRepositories(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICostRepository, CostRepository>();
    }
}