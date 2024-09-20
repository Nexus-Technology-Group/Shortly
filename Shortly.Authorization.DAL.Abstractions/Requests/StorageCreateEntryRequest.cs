namespace Shortly.Authorization.DAL.Abstractions.Requests;

public record StorageCreateEntryRequest(Guid AuthorizationId, string Ip, string UserAgent, string RefreshToken, bool IsEntryAllowed = false);