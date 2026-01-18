using Application.Contracts.Auth;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class IdentityLoginService : IIdentityLoginService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public IdentityLoginService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AuthenticatedUserDto> ValidateCredentialsAsync(string email, string password)
        {

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new AuthenticatedUserDto
                {
                    IsSuccess = false
                };
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

            if (!isPasswordValid)
            {
                return new AuthenticatedUserDto
                {
                    IsSuccess = false
                };
            }

            var roles = await _userManager.GetRolesAsync(user);

            return new AuthenticatedUserDto
            {
                Id = user.Id,
                Email = user.Email!,
                Roles = roles,
                IsSuccess = true
            };
        }
    }
}