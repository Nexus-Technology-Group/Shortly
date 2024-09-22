using Shortly.Codes.Application;
using Shortly.Codes.Application.DTOs;
using Shortly.Codes.Application.Enums;
using Shortly.Codes.Application.Exceptions;
using Shortly.Codes.BLL.Abstractions;
using Shortly.Codes.BLL.Abstractions.Requests;
using Shortly.Codes.DAL.Abstractions;
using Shortly.Codes.DAL.Abstractions.Requests;

namespace Shortly.Codes.BLL.Implementation;

public class CodeManager : ICodeManager, ICodeProvider
{
    private readonly ICodeStorage _codeStorage;

    public CodeManager(ICodeStorage codeStorage)
    {
        _codeStorage = codeStorage;
    }

    public async Task<CodeDTO> CreateAccountConfirmation(string email, CancellationToken cancellationToken)
    {
        var code = await _codeStorage.GetCodeByTypeAsync(new StorageGetCodeByTypeRequest(email, CodeType.Confirmation),
            cancellationToken);

        if (code != null)
            throw new CodeAlreadyExists(CodeAlreadyExists.MESSAGE);

        var expiredDate = DateTime.UtcNow.AddMinutes(CodesConstants.ConfirmationTTL);

        return await _codeStorage.Create(new StorageCreateCodeRequest(email, CodeType.Confirmation, expiredDate),
            cancellationToken);
    }

    public async Task<CodeDTO> CreatePasswordRecovery(string email, CancellationToken cancellationToken)
    {
        var code = await _codeStorage.GetCodeByTypeAsync(
            new StorageGetCodeByTypeRequest(email, CodeType.PasswordRecovery),
            cancellationToken);

        if (code != null)
            throw new CodeAlreadyExists(CodeAlreadyExists.MESSAGE);

        var expiredDate = DateTime.UtcNow.AddMinutes(CodesConstants.PasswordRecoveryTTL);

        return await _codeStorage.Create(new StorageCreateCodeRequest(email, CodeType.PasswordRecovery, expiredDate),
            cancellationToken);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken) =>
        await _codeStorage.RemoveByIdAsync(id, cancellationToken);

    public async Task RemoveAsync(ManagerRemoveCodeRequest request, CancellationToken cancellationToken) =>
        await _codeStorage.RemoveByPayload(new StorageRemoveByPayloadRequest(request.Email, request.Value),
            cancellationToken);

    public async Task IsExistAndValidAsync(string email, string code, CodeType codeType,
        CancellationToken cancellationToken)
    {
        var codeDto =
            await _codeStorage.GetCodeByTypeAsync(new StorageGetCodeByTypeRequest(email, codeType), cancellationToken);

        if (codeDto == null)
            throw new CodeNotFoundException(CodeNotFoundException.MESSAGE);

        if (codeDto.Value != code || codeDto.ExpiredDate < DateTime.UtcNow)
            throw new CodeIsNotValidException(CodeIsNotValidException.MESSAGE);
    }
}