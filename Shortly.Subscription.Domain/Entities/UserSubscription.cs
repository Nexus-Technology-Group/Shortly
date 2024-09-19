namespace Shortly.Subscription.Domain.Entities;

public class UserSubscription
{
    public Guid Id { get; init; }
    public Guid AuthorizationId { get; init; }
    public Guid SubscriptionId { get; init; }
    public DateTime ExpirationTime { get; init; }
}