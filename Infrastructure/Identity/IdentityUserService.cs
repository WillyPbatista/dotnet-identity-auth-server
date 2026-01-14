using Application.Contracts.Auth;
using Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class IdentityUserService : IUserIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityUserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityOperationResult> CreateUserAsync(
        string email,
        string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            return new IdentityOperationResult
            {
                Succeeded = true
            };
        }

        return new IdentityOperationResult
        {
            Succeeded = false,
            Errors = result.Errors.Select(e => e.Description)
        };
    }
}
