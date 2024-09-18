using MongoDB.Driver;
using Shortly.Analytics.Application.DTOs;
using Shortly.Analytics.Application.Mappers;
using Shortly.Analytics.DAL.Abstractions;
using Shortly.Analytics.DAL.Abstractions.Requests;
using Shortly.Analytics.Domain;

namespace Shortly.Analytics.DAL.Mongo;

public class RedirectStorage : IRedirectStorage
{
    #region Constants

    private static readonly InsertOneOptions InsertOneOptions = new()
    {
        BypassDocumentValidation = false
    };

    #endregion
    
    private readonly IMongoCollection<RedirectMetric> _redirectMetricCollection;

    public RedirectStorage(IMongoCollection<RedirectMetric> redirectMetricCollection)
    {
        _redirectMetricCollection = redirectMetricCollection;
    }

    public async Task<RedirectMetricDTO> Create(StorageCreateRedirectMetricRequest request, CancellationToken cancellationToken)
    {
        var metric = new RedirectMetric()
        {
            Id = Guid.NewGuid(),
            AuthorizationId = request.AuthorizationId,
            RedirectTime = request.RedirectTime,
            UrlId = request.UrlId
        };

        await _redirectMetricCollection.InsertOneAsync(metric, InsertOneOptions, cancellationToken);

        return metric.Map();
    }

    public async Task<IReadOnlyCollection<RedirectMetricDTO>> GetByAuthorizationIdAndTime(Guid authorizationId, DateTime from, DateTime to, CancellationToken cancellationToken)
    {
        var filterBuilder = Builders<RedirectMetric>.Filter;
        var filter = filterBuilder.Gte(x => x.RedirectTime, from) & filterBuilder.Lte(x => x.RedirectTime, to);

        var result = await _redirectMetricCollection.Find(filter)
            .ToListAsync(cancellationToken);

        return result.Select(x => x.Map())
            .ToArray();
    }
}