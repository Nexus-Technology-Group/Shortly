using Shortly.Codes.Application.Enums;

namespace Shortly.Codes.BLL.Abstractions;

public interface ICodeProvider
{
    Task IsExistAndValidAsync(string email, string code, CodeType codeType, CancellationToken cancellationToken);
}