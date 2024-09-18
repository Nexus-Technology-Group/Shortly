namespace Shortly.Link.BLL.Abstractions.Requests;

public record ManagerCreateRequest(Guid AuthorizationId, string LongUrl, string? CustomPrefix = null);