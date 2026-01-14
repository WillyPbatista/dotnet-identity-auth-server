
using Application.Interfaces;
using Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.AddScoped<IUserIdentityService, IdentityUserService>();
        return services;
    }
}

