using Shortly.Link.Application.DTOs;
using Shortly.Link.BLL.Abstractions.Requests;

namespace Shortly.Link.BLL.Abstractions;

public interface ILinkManager : ILinkProvider
{
    Task<UrlDTO> Create(ManagerCreateRequest request, CancellationToken cancellationToken);
    Task Delete(Guid id, CancellationToken cancellationToken);
}