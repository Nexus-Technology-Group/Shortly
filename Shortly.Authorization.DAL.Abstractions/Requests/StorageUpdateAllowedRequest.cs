namespace Shortly.Authorization.DAL.Abstractions.Requests;

public record StorageUpdateAllowedRequest(string Ip, bool Value);