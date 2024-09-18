namespace Shortly.Link.Application.DTOs;

public class UrlDTO
{
    public Guid Id { get; init; }
    public Guid AuthorizationId { get; init; }
    public string LongUrl { get; init; } = string.Empty;
    public string ShortUrl { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}