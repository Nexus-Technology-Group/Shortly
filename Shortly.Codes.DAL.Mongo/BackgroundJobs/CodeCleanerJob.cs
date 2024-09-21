using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Shortly.Codes.Domain.Entities;

namespace Shortly.Codes.DAL.Mongo.BackgroundJobs;

public class CodeCleanerJob
{
    private readonly IMongoCollection<Code> _codeCollection;
    private readonly ILogger<CodeCleanerJob> _logger;

    public CodeCleanerJob(IMongoCollection<Code> codeCollection, ILogger<CodeCleanerJob> logger)
    {
        _codeCollection = codeCollection;
        _logger = logger;
    }
    
    public async Task CleanInactiveCodes()
    {
        try
        {
            var filter = Builders<Code>
                .Filter
                .Lt(x => x.ExpiredDate, DateTime.UtcNow);
            
            var result = await _codeCollection.DeleteManyAsync(filter);
            
            _logger.LogInformation("{DeletedCount} неактивных кодов было удалено.", result.DeletedCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при удалении неактивных кодов.");
        }
    }
}