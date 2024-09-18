namespace Shortly.Link.DAL.Abstractions.Requests;

public record StorageCreateRequest(Guid AuthorizationId, string LongUrl, string ShortUrl, DateTimeOffset CreateAt);