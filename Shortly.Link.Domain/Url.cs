namespace Shortly.Link.Domain;

public class Url
{
    public Guid Id { get; init; }
    public Guid AuthorizationId { get; init; }
    public string LongUrl { get; init; } = string.Empty;
    public string ShortUrl { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}