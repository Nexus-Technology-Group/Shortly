namespace Shortly.Authorization.Domain;

public class Authorization
{
    public Guid Id { get; init; }
    public string Login { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}