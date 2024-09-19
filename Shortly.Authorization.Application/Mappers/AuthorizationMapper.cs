using Shortly.Authorization.Application.DTOs;

namespace Shortly.Authorization.Application.Mappers;

public static class AuthorizationMapper
{
    public static AuthorizationDTO Map(this Domain.Authorization authorization)
    {
        return new AuthorizationDTO()
        {
            Id = authorization.Id,
            Login = authorization.Login,
            Password = authorization.Password
        };
    }
}