using MongoDB.Driver;
using Shortly.Link.Application.DTOs;
using Shortly.Link.Application.Exceptions;
using Shortly.Link.Application.Mappers;
using Shortly.Link.DAL.Abstractions;
using Shortly.Link.DAL.Abstractions.Requests;
using Shortly.Link.Domain;

namespace Shortly.Link.DAL.Mongo;

public class LinkStorage : ILinkStorage
{
    #region Constants

    private static readonly InsertOneOptions InsertOneOptions = new()
    {
        BypassDocumentValidation = false
    };

    #endregion

    private readonly IMongoCollection<Url> _linkCollection;

    public LinkStorage(IMongoCollection<Url> linkCollection)
    {
        _linkCollection = linkCollection;
    }

    public async Task<UrlDTO> Create(StorageCreateRequest request, CancellationToken cancellationToken)
    {
        var url = new Url
        {
            Id = Guid.NewGuid(),
            AuthorizationId = request.AuthorizationId,
            LongUrl = request.LongUrl,
            ShortUrl = request.ShortUrl,
            CreatedAt = request.CreateAt.DateTime
        };

        await _linkCollection.InsertOneAsync(url, InsertOneOptions, cancellationToken);

        return url.Map();
    }

    public async Task<UrlDTO> GetByShortUrl(string shortUrl, CancellationToken cancellationToken)
    {
        var filter = Builders<Url>.Filter
            .Eq(x => x.ShortUrl, shortUrl);

        var url = await _linkCollection.Find(filter)
            .FirstOrDefaultAsync(cancellationToken);

        if (url == null)
            throw new MissingUrlException(MissingUrlException.MESSAGE);

        return url.Map();
    }

    public async Task<IReadOnlyCollection<UrlDTO>> GetByAuthorizationId(Guid authorizationId,
        CancellationToken cancellationToken)
    {
        var filter = Builders<Url>.Filter
            .Eq(x => x.AuthorizationId, authorizationId);

        var result = await _linkCollection.Find(filter)
            .ToListAsync(cancellationToken);

        if (result == null)
            throw new MissingUrlException(MissingUrlException.MESSAGE);

        return result.Select(x => x.Map())
            .ToArray();
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<Url>.Filter
            .Eq(x => x.Id, id);

        await _linkCollection.DeleteOneAsync(filter, cancellationToken);
    }
}