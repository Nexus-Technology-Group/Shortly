using Shortly.Authorization.Application.DTOs;
using Shortly.Authorization.DAL.Abstractions.Requests;

namespace Shortly.Authorization.DAL.Abstractions;

public interface IAuthorizationStorage
{
    Task<AuthorizationDTO> Create(StorageCreateAuthorizationRequest request, CancellationToken cancellationToken);
    Task<bool> IsAuthorizationExist(string login, CancellationToken cancellationToken);
}