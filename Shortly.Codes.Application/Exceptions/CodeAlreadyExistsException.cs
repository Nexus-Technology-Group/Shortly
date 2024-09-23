using System.Net;

namespace Shortly.Codes.Application.Exceptions;

public class CodeAlreadyExistsException : HttpRequestException
{
    public const string MESSAGE = "error.code.alreadyExists";

    public CodeAlreadyExistsException(string messsage) : base(messsage, null, HttpStatusCode.Conflict)
    {
    }
}
