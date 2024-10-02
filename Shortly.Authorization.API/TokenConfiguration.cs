namespace Shortly.Authorization.API;

/// <summary>
/// Класс конфигурации токена
/// </summary>
public class TokenConfiguration
{
    /// <summary>
    /// Путь до конфигурации токена в app-settings
    /// </summary>
    public const string PATH = "JwtConfig";
    
    /// <summary>
    /// Секрет
    /// </summary>
    public required string Secret { get; set; }
    
    /// <summary>
    /// Издатель
    /// </summary>
    public required string Issuer { get; set; }
    
    /// <summary>
    /// Аудитория
    /// </summary>
    public required string Audience { get; set; }
}