using Shortly.Link.Application.DTOs;
using Shortly.Link.DAL.Abstractions.Requests;

namespace Shortly.Link.DAL.Abstractions;

public interface ILinkStorage
{
    Task<UrlDTO> Create(StorageCreateRequest request, CancellationToken cancellationToken);
    Task<UrlDTO> GetByShortUrl(string shortUrl, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<UrlDTO>> GetByAuthorizationId(Guid authorizationId, CancellationToken cancellationToken);
    Task Delete(Guid id, CancellationToken cancellationToken);
}