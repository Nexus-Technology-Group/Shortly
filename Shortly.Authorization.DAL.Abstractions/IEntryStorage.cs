using Shortly.Authorization.Application.DTOs;
using Shortly.Authorization.DAL.Abstractions.Requests;

namespace Shortly.Authorization.DAL.Abstractions;

public interface IEntryStorage
{
    Task<EntryDTO> Create(StorageCreateEntryRequest request, CancellationToken cancellationToken);
    Task UpdateRefreshToken(StorageUpdateRefreshTokenRequest request, CancellationToken cancellationToken);
    Task UpdateIsAllowed(StorageUpdateAllowedRequest request, CancellationToken cancellationToken);
}