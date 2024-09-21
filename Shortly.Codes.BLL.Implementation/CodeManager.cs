using Shortly.Codes.Application.DTOs;
using Shortly.Codes.Application.Enums;
using Shortly.Codes.Application.Exceptions;
using Shortly.Codes.BLL.Abstractions;
using Shortly.Codes.BLL.Abstractions.Requests;
using Shortly.Codes.DAL.Abstractions;
using Shortly.Codes.DAL.Abstractions.Requests;

namespace Shortly.Codes.BLL.Implementation;

public class CodeManager : ICodeManager
{
    private readonly ICodeStorage _codeStorage;

    public CodeManager(ICodeStorage codeStorage)
    {
        _codeStorage = codeStorage;
    }

    public async Task<CodeDTO> CreateAccountConfirmationCode(string email, CancellationToken cancellationToken)
    {
        var code = await _codeStorage.GetCodeByTypeAsync(new StorageGetCodeByTypeRequest(email, CodeType.Confirmation),
            cancellationToken);

        if (code != null)
            throw new CodeAlreadyExists(CodeAlreadyExists.MESSAGE);

        var expiredDate = DateTime.UtcNow.AddMinutes(CodesConstants.ConfirmationExpirationTime);

        return await _codeStorage.Create(new StorageCreateCodeRequest(email, CodeType.Confirmation, expiredDate),
            cancellationToken);
    }

    public async Task<CodeDTO> CreatePasswordRecoveryCode(string email, CancellationToken cancellationToken)
    {
        var code = await _codeStorage.GetCodeByTypeAsync(
            new StorageGetCodeByTypeRequest(email, CodeType.PasswordRecovery),
            cancellationToken);

        if (code != null)
            throw new CodeAlreadyExists(CodeAlreadyExists.MESSAGE);

        var expiredDate = DateTime.UtcNow.AddMinutes(CodesConstants.PasswordRecoveryExpirationTime);

        return await _codeStorage.Create(new StorageCreateCodeRequest(email, CodeType.PasswordRecovery, expiredDate),
            cancellationToken);
    }

    public async Task RemoveCodeAsync(Guid id, CancellationToken cancellationToken) =>
        await _codeStorage.RemoveByIdAsync(id, cancellationToken);

    public async Task RemoveCodeAsync(RemoveCodeRequest request, CancellationToken cancellationToken) =>
        await _codeStorage.RemoveByPayload(new StorageRemoveByPayloadRequest(request.Email, request.Value),
            cancellationToken);
}