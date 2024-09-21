using System.Net;

namespace Shortly.Codes.Application.Exceptions;

public class CodeAlreadyExists : HttpRequestException
{
    public const string MESSAGE = "error.code.already.exists";

    public CodeAlreadyExists(string messsage) : base(messsage, null, HttpStatusCode.Conflict)
    {
    }
}
