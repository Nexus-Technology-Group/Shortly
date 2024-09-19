namespace Shortly.Subscription.Domain.Entities;

public class Subscription
{
    public Guid Id { get; init; }
    public string Label { get; init; } = string.Empty;
    public int Limit { get; init; }
    public int Cost { get; init; }
}