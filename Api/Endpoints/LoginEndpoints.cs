using Application.Contracts.Auth;
using Application.Interfaces;

namespace Api.Endpoints
{
    public class LoginEndpoints
    {

                public static void MapLoginEndpoints(IEndpointRouteBuilder app)
        {
            app.MapPost("/login", async (LoginRequest loginRequest, ILoginUser loginUser) =>
            {
                try
                {
                    var loginResponse = await loginUser.LoginAsync(loginRequest.Email, loginRequest.Password);
                    if (!loginResponse.IsSuccess)
                    {
                        return Results.Unauthorized();
                    }

                    return Results.Ok(loginResponse);
                }
                catch (Exception ex)
                {
                    return Results.Problem(detail: ex.Message);
                }
            })
            .WithName("Login")
            .WithTags("Login")
            .Produces<LoginResponse>(StatusCodes.Status200OK);
        }
    }
}