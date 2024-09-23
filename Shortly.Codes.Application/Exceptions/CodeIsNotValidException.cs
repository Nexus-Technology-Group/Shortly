using System.Net;

namespace Shortly.Codes.Application.Exceptions;

public class CodeIsNotValidException : HttpRequestException
{
    public const string MESSAGE = "error.code.invalid";
    public CodeIsNotValidException(string messsage) : base(messsage, null, HttpStatusCode.BadRequest)
    {
        
    }
}