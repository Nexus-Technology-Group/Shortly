namespace Shortly.Authorization.BLL.Abstractions.Requests;

public record ManagerCreateAuthorizationRequest(string Login, string Password);