using Application.Contracts.Auth;

namespace Application.Interfaces
{
    public interface IRegisterUser
    {
        Task RegisterAsync(RegisterRequest request);
    }
}