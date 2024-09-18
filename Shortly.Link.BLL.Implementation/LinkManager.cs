using Shortly.Link.Application.DTOs;
using Shortly.Link.Application.Generator;
using Shortly.Link.BLL.Abstractions;
using Shortly.Link.BLL.Abstractions.Requests;
using Shortly.Link.DAL.Abstractions;
using Shortly.Link.DAL.Abstractions.Requests;

namespace Shortly.Link.BLL.Implementation;

public class LinkManager : ILinkManager
{
    private readonly ILinkStorage _linkStorage;

    public LinkManager(ILinkStorage linkStorage)
    {
        _linkStorage = linkStorage;
    }

    public async Task<UrlDTO> Create(ManagerCreateRequest request, CancellationToken cancellationToken)
    {
        string url;

        if (string.IsNullOrEmpty(request.CustomPrefix))
        {
            url = RandomStringGenerator.GenerateRandomString();
        }
        else
        {
            var remainingLength = 12 - request.CustomPrefix.Length;
            url = request.CustomPrefix + RandomStringGenerator.GenerateRandomString(remainingLength);
        }

        var storageRequest =
            new StorageCreateRequest(request.AuthorizationId, request.LongUrl, url, DateTimeOffset.UtcNow);

        return await _linkStorage.Create(storageRequest, cancellationToken);
    }

    public async Task<string> GetUrlByShort(string shortUrl, CancellationToken cancellationToken)
    {
        var dto = await _linkStorage.GetByShortUrl(shortUrl, cancellationToken);

        return dto.LongUrl;
    }

    public async Task<IReadOnlyCollection<UrlDTO>> GetByAuthorizationId(Guid authorizationId,
        CancellationToken cancellationToken)
    {
        return await _linkStorage.GetByAuthorizationId(authorizationId, cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
         await _linkStorage.Delete(id, cancellationToken);
    }
}