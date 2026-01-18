using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Security
{

    public class JwtTokenService : ITokenService
    {
            private readonly JwtSettings _jwtSettings;

    public JwtTokenService( IOptions<JwtSettings> options)
    {
        _jwtSettings = options.Value;
    }

        public string GenerateToken(string userId, string email, IList<string> roles)
        {
            var clams = new List<Claim>
            { 
                new Claim("sub", userId),
                new Claim("email", email),
                //new Claim("roles", string.Join(",", roles))
            };
            foreach (var role in roles)
            {
                clams.Add(new Claim("roles", role));
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: clams,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}