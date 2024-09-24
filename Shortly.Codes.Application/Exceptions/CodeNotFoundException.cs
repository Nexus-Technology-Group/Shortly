using System.Net;

namespace Shortly.Codes.Application.Exceptions;

public class CodeNotFoundException : HttpRequestException
{
    public const string MESSAGE = "error.code.notFound";

    public CodeNotFoundException(string messsage) : base(messsage, null, HttpStatusCode.NotFound)
    {
    }
}