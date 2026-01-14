using Application.Contracts.Auth;
using Application.Interfaces;

namespace Application.Register;

public class RegisterUser : IRegisterUser
{
    private readonly IUserIdentityService _identityService;

    public RegisterUser(IUserIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {

        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.Email))
            throw new ArgumentException("Email is required");

        if (string.IsNullOrWhiteSpace(request.Password))
            throw new ArgumentException("Password is required");

        var result = await _identityService.CreateUserAsync(
            request.Email,
            request.Password
        );

        if (!result.Succeeded)
        {
            throw new InvalidOperationException(
                string.Join(", ", result.Errors)
            );
        }
    }
}
