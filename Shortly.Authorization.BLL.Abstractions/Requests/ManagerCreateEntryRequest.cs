namespace Shortly.Authorization.BLL.Abstractions.Requests;

public record ManagerCreateEntryRequest(Guid AuthorizationId, string Ip, string UserAgent, string RefreshToken, bool IsEntryAllowed = false);