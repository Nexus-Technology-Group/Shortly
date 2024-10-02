using Shortly.Authorization.Application.DTOs;
using Shortly.Authorization.BLL.Abstractions;
using Shortly.Authorization.BLL.Abstractions.Managers;
using Shortly.Authorization.BLL.Abstractions.Requests;
using Shortly.Authorization.DAL.Abstractions;
using Shortly.Authorization.DAL.Abstractions.Requests;

namespace Shortly.Authorization.BLL.Implementation;

public class EntryManager : IEntryManager
{
    private readonly IEntryStorage _entryStorage;

    public EntryManager(IEntryStorage entryStorage)
    {
        _entryStorage = entryStorage;
    }

    public async Task<EntryDTO> Create(ManagerCreateEntryRequest request, CancellationToken cancellationToken)
    {
        return await _entryStorage.Create(new StorageCreateEntryRequest(request.AuthorizationId, request.Ip,
            request.UserAgent, request.RefreshToken, request.IsEntryAllowed), cancellationToken);
    }

    public async Task UpdateToken(ManagerUpdateRefreshTokenRequest request, CancellationToken cancellationToken)
    {
        await _entryStorage.UpdateRefreshToken(
            new StorageUpdateRefreshTokenRequest(request.AuthorizationId, request.RefreshToken), cancellationToken);
    }

    public async Task Approve(string ip, CancellationToken cancellationToken)
    {
        await _entryStorage.UpdateIsAllowed(new StorageUpdateAllowedRequest(ip, true), cancellationToken);
    }
}