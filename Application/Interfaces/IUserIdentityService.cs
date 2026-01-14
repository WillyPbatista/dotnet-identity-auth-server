using Application.Contracts.Auth;

namespace Application.Interfaces;


public interface IUserIdentityService
{
    Task<IdentityOperationResult> CreateUserAsync(
        string email,
        string password
    );
}
