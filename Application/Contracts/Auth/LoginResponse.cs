namespace Application.Contracts.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; } = null!;
        public string Expires_In { get; set; } = null!;
        public string TokenType { get; set; }= null!;
        public bool IsSuccess { get; set;  }= true;
    }
}