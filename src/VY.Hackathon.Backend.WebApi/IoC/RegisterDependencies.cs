using Microsoft.Extensions.DependencyInjection.Extensions;
using VY.Hackathon.Backend.Business;
using VY.Hackathon.Backend.Business.Contracts;

namespace VY.Hackathon.Backend.WebApi.IoC;

public static class RegisterDependencies
{
    public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddSingleton<IHandlingService, HandlingService>();
        return serviceCollection;
    } 
}