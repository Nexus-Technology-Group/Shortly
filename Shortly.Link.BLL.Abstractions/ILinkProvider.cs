using Shortly.Link.Application.DTOs;

namespace Shortly.Link.BLL.Abstractions;

public interface ILinkProvider
{
    Task<string> GetUrlByShort(string shortUrl, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<UrlDTO>> GetByAuthorizationId(Guid authorizationId, CancellationToken cancellationToken);
}