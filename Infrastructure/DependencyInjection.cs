
using Application.Interfaces;
using Application.Security;
using Infrastructure.Identity;
using Infrastructure.Security;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.AddScoped<IUserIdentityService, IdentityUserService>();
        services.AddScoped<IIdentityLoginService, IdentityLoginService>();
        services.AddScoped<ITokenService, JwtTokenService>();
        services.Configure<Security.JwtSettings>(
            configuration.GetSection("JwtSettings"));
        return services;
    }
}

