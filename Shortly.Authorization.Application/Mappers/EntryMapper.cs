using Shortly.Authorization.Application.DTOs;
using Shortly.Authorization.Domain;

namespace Shortly.Authorization.Application.Mappers;

public static class EntryMapper
{
    public static EntryDTO Map(this Entry entry)
    {
        return new EntryDTO
        {
            Id = entry.Id,
            AuthorizationId = entry.AuthorizationId,
            Ip = entry.Ip,
            UserAgent = entry.UserAgent,
            RefreshToken = entry.RefreshToken,
            IsAllowed = entry.IsAllowed
        };
    }
}