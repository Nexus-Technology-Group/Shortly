using System.Net;

namespace Shortly.Authorization.Application.Exceptions;

public class UserAlreadyExistException : HttpRequestException
{
    public const string MESSAGE = "error.authorization.alreadyExist";
    
    public UserAlreadyExistException(string reasonPhrase) : base(reasonPhrase, null, HttpStatusCode.BadRequest)
    {
        
    }
}