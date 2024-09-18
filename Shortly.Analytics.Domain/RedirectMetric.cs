namespace Shortly.Analytics.Domain;

public class RedirectMetric
{
    public Guid Id { get; init; }
    public Guid UrlId { get; init; }
    public Guid AuthorizationId { get; init; }
    public DateTime RedirectTime { get; init; }
}