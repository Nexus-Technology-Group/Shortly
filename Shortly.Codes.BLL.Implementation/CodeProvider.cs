using Shortly.Codes.Application.Enums;
using Shortly.Codes.Application.Exceptions;
using Shortly.Codes.BLL.Abstractions;
using Shortly.Codes.DAL.Abstractions;
using Shortly.Codes.DAL.Abstractions.Requests;

namespace Shortly.Codes.BLL.Implementation;

public class CodeProvider : ICodeProvider
{
    private readonly ICodeStorage _codeStorage;

    public CodeProvider(ICodeStorage codeStorage)
    {
        _codeStorage = codeStorage;
    }

    public async Task IsCodeExistAndValidAsync(string email, string code, CodeType codeType,
        CancellationToken cancellationToken)
    {
        var codeDto =
            await _codeStorage.GetCodeByTypeAsync(new StorageGetCodeByTypeRequest(email, codeType), cancellationToken);

        if (codeDto == null)
            throw new CodeNotFoundException(CodeNotFoundException.MESSAGE);

        var todayDate = DateTime.UtcNow;

        if (codeDto.Value != code || codeDto.ExpiredDate < todayDate)
            throw new CodeIsNotValidException(CodeIsNotValidException.MESSAGE);
    }
}