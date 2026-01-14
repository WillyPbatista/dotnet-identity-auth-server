
using Application.Interfaces;
using Application.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection{

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IRegisterUser, RegisterUser>();

        return services;
    }
}
}