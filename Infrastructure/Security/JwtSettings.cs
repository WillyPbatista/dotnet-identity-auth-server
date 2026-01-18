namespace Infrastructure.Security
{
    public class JwtSettings
    {
        public string Key { get; set; } = null!;             
        public string Issuer { get; set; } = "IdentityServer";
        public string Audience { get; set; } = "IdentityServerClients";
        public int ExpirationMinutes { get; set; } = 60;
    }
}