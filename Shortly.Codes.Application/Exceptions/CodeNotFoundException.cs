using System.Net;

namespace Shortly.Codes.Application.Exceptions;

public class CodeNotFoundException : HttpRequestException
{
    public const string MESSAGE = "error.code.not.found";

    public CodeNotFoundException(string messsage) : base(messsage, null, HttpStatusCode.NotFound)
    {
    }
}