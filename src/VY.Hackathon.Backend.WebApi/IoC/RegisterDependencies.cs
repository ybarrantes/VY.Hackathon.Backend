using VY.Hackathon.Backend.Business;
using VY.Hackathon.Backend.Business.Contracts;

namespace VY.Hackathon.Backend.WebApi.IoC;

public static class RegisterDependencies
{
    public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection)
    {
        RegisterServices(serviceCollection);
        
        return serviceCollection;
    }

    private static void RegisterServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IHandlingService, HandlingService>();
        serviceCollection.AddSingleton<ICostService, CostService>();
        serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}