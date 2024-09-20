using Microsoft.EntityFrameworkCore;
using Shortly.Authorization.Application.DTOs;
using Shortly.Authorization.Application.Mappers;
using Shortly.Authorization.DAL.Abstractions;
using Shortly.Authorization.DAL.Abstractions.Requests;
using Shortly.Authorization.DAL.PostgreSQL.Context;
using Shortly.Authorization.Domain;

namespace Shortly.Authorization.DAL.PostgreSQL;

public class EntryStorage : IEntryStorage
{
    private readonly IEntryContext _context;

    public EntryStorage(IEntryContext context)
    {
        _context = context;
    }

    public async Task<EntryDTO> Create(StorageCreateEntryRequest request, CancellationToken cancellationToken)
    {
        var entry = new Entry()
        {
            Id = Guid.NewGuid(),
            AuthorizationId = request.AuthorizationId,
            Ip = request.Ip,
            UserAgent = request.UserAgent,
            RefreshToken = request.RefreshToken,
            IsAllowed = request.IsEntryAllowed
        };

        _context.Entries
            .Add(entry);

        await _context.SaveChangesAsync(cancellationToken);

        return entry.Map();
    }

    public async Task UpdateRefreshToken(StorageUpdateRefreshTokenRequest request, CancellationToken cancellationToken)
    {
        await _context.Entries
            .Where(x => x.AuthorizationId == request.AuthorizationId)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.RefreshToken, request.RefreshToken), cancellationToken);
    }

    public async Task UpdateIsAllowed(StorageUpdateAllowedRequest request, CancellationToken cancellationToken)
    {
        await _context.Entries
            .Where(x => x.Ip == request.Ip)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.IsAllowed, request.Value), cancellationToken);
    }
}