using Shortly.Codes.Application.Enums;

namespace Shortly.Codes.BLL.Abstractions;

public interface ICodeProvider
{
    Task IsCodeExistAndValidAsync(string email, string code, CodeType codeType, CancellationToken cancellationToken);
}