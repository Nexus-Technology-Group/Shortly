namespace Shortly.Authorization.Application.DTOs;

public class EntryDTO
{
    public Guid Id { get; init; }
    public Guid AuthorizationId { get; init; }
    public string Ip { get; init; } = string.Empty;
    public string UserAgent { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
    public bool IsAllowed { get; init; }
}