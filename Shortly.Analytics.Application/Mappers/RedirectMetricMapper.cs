using Shortly.Analytics.Application.DTOs;
using Shortly.Analytics.Domain;

namespace Shortly.Analytics.Application.Mappers;

public static class RedirectMetricMapper
{
    public static RedirectMetricDTO Map(this RedirectMetric metric)
    {
        return new RedirectMetricDTO
        {
            Id = metric.Id,
            AuthorizationId = metric.AuthorizationId,
            UrlId = metric.UrlId,
            RedirectTime = metric.RedirectTime
        };
    }
}