using Shortly.Codes.Application.DTOs;
using Shortly.Codes.BLL.Abstractions.Requests;

namespace Shortly.Codes.BLL.Abstractions;

public interface ICodeManager
{
    Task<CodeDTO> CreateAccountConfirmation(string email, CancellationToken cancellationToken);
    
    Task<CodeDTO> CreatePasswordRecovery(string email, CancellationToken cancellationToken);
    
    Task RemoveAsync(Guid id, CancellationToken cancellationToken);
    
    Task RemoveAsync(ManagerRemoveCodeRequest request, CancellationToken cancellationToken);
}