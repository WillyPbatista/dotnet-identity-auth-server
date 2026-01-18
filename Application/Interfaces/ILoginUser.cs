using Application.Contracts.Auth;

namespace Application.Interfaces
{
    public interface ILoginUser
{
    Task<LoginResponse> LoginAsync(string email, string password);
}
}