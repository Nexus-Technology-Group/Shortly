using MongoDB.Driver;
using Shortly.Codes.Application.DTOs;
using Shortly.Codes.Application.Utils;
using Shortly.Codes.DAL.Abstractions;
using Shortly.Codes.DAL.Abstractions.Requests;
using Shortly.Codes.DAL.Mongo.Utils;
using Shortly.Codes.Domain.Entities;

namespace Shortly.Codes.DAL.Mongo;

public class CodeStorage : ICodeStorage
{
    #region Constants

    private static readonly InsertOneOptions InsertOneOptions = new()
    {
        BypassDocumentValidation = false
    };
    
    #endregion
    
    private readonly IMongoCollection<Code> _codeCollection;

    public CodeStorage(IMongoCollection<Code> codeCollection)
    {
        _codeCollection = codeCollection;
    }

    public async Task<CodeDTO> Create(StorageCreateCodeRequest request, CancellationToken cancellationToken)
    {
        var code = new Code()
        {
            Type = request.Type,
            Value = CodeGenerator.Generate(),
            Email = request.Email,
            CreateDate = DateTime.UtcNow,
            ExpiredDate = request.ExpiredDate
        };

        await _codeCollection.InsertOneAsync(code, InsertOneOptions, cancellationToken);

        return code.Map();
    }

    public async Task<CodeDTO?> GetCodeByValue(string value, CancellationToken cancellationToken)
    {
        var filter = Builders<Code>.Filter.Eq(x => x.Value, value);
        
        var code = await _codeCollection.Find(filter)
            .FirstOrDefaultAsync(cancellationToken);

        return code?.Map();
    }

    public async Task<CodeDTO?> GetCodeByTypeAsync(StorageGetCodeByTypeRequest request, CancellationToken cancellationToken)
    {
        var filter = Builders<Code>.Filter.And(
            Builders<Code>.Filter.Eq(x => x.Email, request.Email),
            Builders<Code>.Filter.Eq(x => x.Type, request.Type));
        
        var code = await _codeCollection.Find(filter).FirstOrDefaultAsync(cancellationToken);

        return code?.Map();
    }

    public async Task RemoveByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<Code>.Filter
            .Eq(x => x.Id, id);
        
        await _codeCollection.DeleteOneAsync(filter, cancellationToken);
    }

    public async Task RemoveByPayload(StorageRemoveByPayloadRequest request, CancellationToken cancellationToken)
    {
        var filter = Builders<Code>.Filter.And(
            Builders<Code>.Filter.Eq(x => x.Email, request.Email),
            Builders<Code>.Filter.Eq(x => x.Value, request.Value));
        
        await _codeCollection.DeleteOneAsync(filter, cancellationToken);
    }
}