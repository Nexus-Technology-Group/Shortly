using Shortly.Authorization.Application.DTOs;
using Shortly.Authorization.BLL.Abstractions.Requests;

namespace Shortly.Authorization.BLL.Abstractions.Managers;

public interface IEntryManager
{
    Task<EntryDTO> Create(ManagerCreateEntryRequest request, CancellationToken cancellationToken);

    Task UpdateToken(ManagerUpdateRefreshTokenRequest request, CancellationToken cancellationToken);
    Task Approve(string ip, CancellationToken cancellationToken);
}