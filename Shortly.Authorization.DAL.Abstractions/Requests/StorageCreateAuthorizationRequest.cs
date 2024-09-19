namespace Shortly.Authorization.DAL.Abstractions.Requests;

public record StorageCreateAuthorizationRequest(string Login, string Password);