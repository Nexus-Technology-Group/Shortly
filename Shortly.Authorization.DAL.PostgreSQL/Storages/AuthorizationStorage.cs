using Microsoft.EntityFrameworkCore;
using Shortly.Authorization.Application.DTOs;
using Shortly.Authorization.Application.Mappers;
using Shortly.Authorization.DAL.Abstractions;
using Shortly.Authorization.DAL.Abstractions.Requests;
using Shortly.Authorization.DAL.PostgreSQL.Context;

namespace Shortly.Authorization.DAL.PostgreSQL;

public class AuthorizationStorage : IAuthorizationStorage
{
    private readonly IAuthorizationContext _context;

    public AuthorizationStorage(IAuthorizationContext context)
    {
        _context = context;
    }

    public async Task<AuthorizationDTO> Create(StorageCreateAuthorizationRequest request, CancellationToken cancellationToken)
    {
        var authorization = new Domain.Authorization()
        {
            Id = Guid.NewGuid(),
            Login = request.Login,
            Password = request.Password
        };

        _context.Authorizations
            .Add(authorization);

        await _context.SaveChangesAsync(cancellationToken);

        return authorization.Map();
    }

    public async Task<bool> IsAuthorizationExist(string login, CancellationToken cancellationToken)
    {
        return await _context.Authorizations
            .Where(x => x.Login == login)
            .AnyAsync(cancellationToken);
    }
}