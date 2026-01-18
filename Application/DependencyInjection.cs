
using Application.Interfaces;
using Application.Login;
using Application.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection{

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IRegisterUser, RegisterUser>();
        services.AddScoped<ILoginUser, LoginUser>();
        

        return services;
    }
}
}