using Application.Contracts.Auth;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing; 
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints
{
    public class AuthEndpoints
    {
        public static void MapAuthEndpoints(IEndpointRouteBuilder app)
        {
            app.MapPost("/register-user", async (RegisterRequest request, [FromServices] IRegisterUser registerUser) =>
            {
                try
                {
                    await registerUser.RegisterAsync(request);

                    var response = new RegisterResponse
                    {
                        Email = request.Email,
                        UserName = request.Email,
                        Message = "User registered"
                    };

                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    return Results.Problem(detail: ex.Message);
                }
            })
            .WithName("Register")
            .WithTags("Auth")
            .Produces<RegisterResponse>(StatusCodes.Status200OK);
        }
    }
}