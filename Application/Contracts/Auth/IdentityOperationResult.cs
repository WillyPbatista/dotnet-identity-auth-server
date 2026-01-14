namespace Application.Contracts.Auth;

public class IdentityOperationResult
{
    public bool Succeeded { get; init; }
    public IEnumerable<string> Errors { get; init; } = [];
}
