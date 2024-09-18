namespace Shortly.Analytics.DAL.Abstractions.Requests;

public record StorageCreateRedirectMetricRequest(Guid UrlId, Guid AuthorizationId, DateTime RedirectTime);