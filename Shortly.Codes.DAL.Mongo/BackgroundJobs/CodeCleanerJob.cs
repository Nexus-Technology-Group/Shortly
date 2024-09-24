using Microsoft.Extensions.Logging;
using Shortly.Codes.DAL.Abstractions;

namespace Shortly.Codes.DAL.Mongo.BackgroundJobs;

public class CodeCleanerJob
{
    private readonly ICodeStorage _codeStorage;
    private readonly ILogger<CodeCleanerJob> _logger;

    public CodeCleanerJob(ILogger<CodeCleanerJob> logger, ICodeStorage codeStorage)
    {
        _logger = logger;
        _codeStorage = codeStorage;
    }
    
    public async Task CleanInactiveCodes()
    {
        try
        {
            var deletedCount = await _codeStorage.DeleteExpiredCodes();
            
            _logger.LogInformation("{DeletedCount} неактивных кодов было удалено.", deletedCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при удалении неактивных кодов.");
        }
    }
}