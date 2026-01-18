using Application.Contracts.Auth;
using Application.Interfaces;
using Application.Security;

namespace Application.Login
{
    public class LoginUser : ILoginUser
    {
        private readonly IIdentityLoginService _identityLoginService;
        private readonly ITokenService _tokenService;

        public LoginUser(IIdentityLoginService identityLoginService, ITokenService tokenService)
        {
            _identityLoginService = identityLoginService;
            _tokenService = tokenService;
        }
        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            var authResult = await _identityLoginService.ValidateCredentialsAsync(email, password);

            if (!authResult.IsSuccess)
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    Token = null
                };
            }

            var token =  _tokenService.GenerateToken(authResult.Id , authResult.Email, authResult.Roles);

            return  new LoginResponse
            {
                IsSuccess = true,
                Token = token,
                Expires_In = "3600",
                TokenType = "Bearer"
            };
        }
    }
}