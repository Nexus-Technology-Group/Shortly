namespace Shortly.Authorization.BLL.Abstractions.Requests;

public record ManagerUpdateRefreshTokenRequest(Guid AuthorizationId, string RefreshToken);