namespace Shortly.Authorization.Application.DTOs;

public class AuthorizationDTO
{
    public Guid Id { get; init; }
    public string Login { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}