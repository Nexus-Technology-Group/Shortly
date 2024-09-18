using Shortly.Link.Application.DTOs;
using Shortly.Link.Domain;

namespace Shortly.Link.Application.Mappers;

public static class UrlMapper
{
    public static UrlDTO Map(this Url url)
    {
        return new UrlDTO()
        {
            Id = url.Id,
            AuthorizationId = url.AuthorizationId,
            LongUrl = url.LongUrl,
            ShortUrl = url.ShortUrl,
            CreatedAt = url.CreatedAt
        };
    }
}