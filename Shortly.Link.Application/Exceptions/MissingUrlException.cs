using System.Net;

namespace Shortly.Link.Application.Exceptions;

public class MissingUrlException : HttpRequestException
{
    public const string MESSAGE = "error.url.missing";
    
    public MissingUrlException(string message) : base(message, null, HttpStatusCode.NotFound)
    {
        
    }
}