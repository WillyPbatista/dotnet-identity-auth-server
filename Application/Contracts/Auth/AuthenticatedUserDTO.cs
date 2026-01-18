public class AuthenticatedUserDto
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;
    public IList<string> Roles { get; set; } = null!;
    public bool IsSuccess { get; set; }
}