using Shortly.Authorization.Application.DTOs;
using Shortly.Authorization.Application.Exceptions;
using Shortly.Authorization.BLL.Abstractions;
using Shortly.Authorization.BLL.Abstractions.Requests;
using Shortly.Authorization.DAL.Abstractions;
using Shortly.Authorization.DAL.Abstractions.Requests;
using Shortly.Authorization.Domain.Utils;

namespace Shortly.Authorization.BLL.Implementation;

public class AuthorizationManager : IAuthorizationManager
{
    private readonly IAuthorizationStorage _authorizationStorage;

    public AuthorizationManager(IAuthorizationStorage authorizationStorage)
    {
        _authorizationStorage = authorizationStorage;
    }

    public async Task<AuthorizationDTO> Create(ManagerCreateAuthorizationRequest request, CancellationToken cancellationToken)
    {
        if (await _authorizationStorage.IsAuthorizationExist(request.Login, cancellationToken))
            throw new UserAlreadyExistException(UserAlreadyExistException.MESSAGE);
        
        var password = Hasher.ComputeHash(request.Password);

        return await _authorizationStorage.Create(new StorageCreateAuthorizationRequest(request.Login, password),
            cancellationToken);
    }
}