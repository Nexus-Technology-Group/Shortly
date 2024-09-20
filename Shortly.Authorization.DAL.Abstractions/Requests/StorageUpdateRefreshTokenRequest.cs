namespace Shortly.Authorization.DAL.Abstractions.Requests;

public record StorageUpdateRefreshTokenRequest(Guid AuthorizationId, string RefreshToken);