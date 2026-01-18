using Application.Contracts.Auth;

public interface IIdentityLoginService
{
    Task<AuthenticatedUserDto> ValidateCredentialsAsync(string email, string password);
}