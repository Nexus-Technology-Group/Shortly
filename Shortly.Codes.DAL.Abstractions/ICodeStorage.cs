using Shortly.Codes.Application.DTOs;
using Shortly.Codes.DAL.Abstractions.Requests;

namespace Shortly.Codes.DAL.Abstractions;

public interface ICodeStorage
{
    Task<CodeDTO> Create(StorageCreateCodeRequest request, CancellationToken cancellationToken);

    Task<CodeDTO?> GetCodeByValue(string value, CancellationToken cancellationToken);

    Task<CodeDTO?> GetCodeByTypeAsync(StorageGetCodeByTypeRequest request, CancellationToken cancellationToken);
    
    Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task RemoveByPayload(StorageRemoveByPayloadRequest request, CancellationToken cancellationToken);

    Task<long> DeleteExpiredCodes();
}