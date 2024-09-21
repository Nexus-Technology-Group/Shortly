using Shortly.Codes.Application.DTOs;
using Shortly.Codes.BLL.Abstractions.Requests;

namespace Shortly.Codes.BLL.Abstractions;

public interface ICodeManager
{
    Task<CodeDTO> CreateAccountConfirmationCode(string email, CancellationToken cancellationToken);
    
    Task<CodeDTO> CreatePasswordRecoveryCode(string email, CancellationToken cancellationToken);
    
    Task RemoveCodeAsync(Guid id, CancellationToken cancellationToken);
    
    Task RemoveCodeAsync(RemoveCodeRequest request, CancellationToken cancellationToken);
}